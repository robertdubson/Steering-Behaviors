using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace Game
{
    public partial class Game : Form
    {
        List<Button> _sprites;

        List<IActor> actors;

        Dictionary<Button, IActor> spritesToActors;

        Dictionary<IActor, Button> actorsToSprites;

        Hunter _player;

        Button _hunter;

        List<IActor> killed;

        List<Bullet> bullets;

        public Game()
        {
            InitializeComponent();

            killed = new List<IActor>();

            BackColor = Color.DarkGreen;

            KeyPreview = true;

            KeyDown += Game_KeyDown;

            Click += Game_Click;

            spritesToActors = new Dictionary<Button, IActor>();

            actorsToSprites = new Dictionary<IActor, Button>();

            _sprites = new List<Button>();

            actors = new List<IActor>();

            actors.Add(new Wolf(this.Height, this.Width, actors));

            actors.Add(new Wolf(this.Height, this.Width, actors));

            actors.Add(new Wolf(this.Height, this.Width, actors));

            actors.Add(new Doe(this.Height, this.Width, actors));

            actors.Add(new Doe(this.Height, this.Width, actors));
            actors.Add(new Doe(this.Height, this.Width, actors));
            actors.Add(new Doe(this.Height, this.Width, actors));
            actors.Add(new Doe(this.Height, this.Width, actors));


            actors.Add(new Hare(this.Height, this.Width, actors));
            actors.Add(new Hare(this.Height, this.Width, actors));
            actors.Add(new Hare(this.Height, this.Width, actors));
            actors.Add(new Hare(this.Height, this.Width, actors));

            Hunter hunter = new Hunter(actors);

            hunter.Location = new System.Numerics.Vector2(50, 50);

            _player = hunter;

            actors.Add(hunter);

            foreach (IActor a in actors)
            {
                Button sprite = new Button();

                sprite.Location = new Point((int)a.Location.X, (int)a.Location.Y);

                sprite.Enabled = false;

                if (a is Hunter)
                {
                    sprite.Height = 50;

                    sprite.Width = sprite.Height;

                    sprite.BackColor = Color.Red;

                    _hunter = sprite;

                }
                else if (a is Doe)
                {

                    sprite.Height = 30;

                    sprite.Width = sprite.Height;

                    sprite.BackColor = Color.Brown;

                }
                else if (a is Wolf)
                {
                    sprite.Height = 33;

                    sprite.Width = sprite.Height;

                    sprite.BackColor = Color.DarkGray;

                }
                else if (a is Hare)
                {
                    sprite.Height = 30;

                    sprite.Width = sprite.Height;

                    sprite.BackColor = Color.Pink;

                }

                a.Actors = actors;

                GraphicsPath p = new GraphicsPath();

                p.AddEllipse(1, 1, sprite.Width - 4, sprite.Height - 4);

                sprite.Region = new Region(p);

                actorsToSprites.Add(a, sprite);

                spritesToActors.Add(sprite, a);

                Controls.Add(sprite);

                bullets = new List<Bullet>();

            }

        }



        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            int walkDistance = 5;

            switch (e.KeyCode) {

                case Keys.W:
                    _hunter.Top -= walkDistance;
                    break;
                case Keys.Up:
                    _hunter.Top -= walkDistance;
                    break;
                case Keys.Down:
                    _hunter.Top += walkDistance;
                    break;
                case Keys.S:
                    _hunter.Top += walkDistance;
                    break;
                case Keys.D:
                    _hunter.Left += walkDistance;
                    break;
                case Keys.Right:
                    _hunter.Left += walkDistance;
                    break;
                case Keys.Left:
                    _hunter.Left -= walkDistance;
                    break;
                case Keys.A:
                    _hunter.Left -= walkDistance;
                    break;




            }

        }

        private void Game_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            Hunter curHunter = (Hunter)spritesToActors[_hunter];

            if (_player.BulletCounter>0) 
            {
                Bullet bullet = new Bullet(_hunter, curHunter.Location, new Vector2(Cursor.Position.X, Cursor.Position.Y));

                Controls.Add(bullet.BulletSprite);

                bullets.Add(bullet);

                _player.BulletCounter--;

            }
   

        }

        private void GameLoop()
        {
            foreach (IActor a in actors)
            {
                if (!(a is Hunter))
                {
                    a.Applier.ApplyBehavior();
                    actorsToSprites[a].Location = new Point((int)a.Location.X, (int)a.Location.Y);

                    Bullet curBullet = bullets.Find(b => b.BulletSprite.Bounds.IntersectsWith(actorsToSprites[a].Bounds));
                    if (bullets.Contains(bullets.Find(b => b.BulletSprite.Bounds.IntersectsWith(actorsToSprites[a].Bounds)))) {

                        //actors.Remove(a);

                        killed.Add(a);
                        
                        actorsToSprites[a].Dispose();

                        curBullet.BulletSprite.Dispose();

                    }

                }
                else {

                    a.Location = new System.Numerics.Vector2(_hunter.Location.X, _hunter.Location.Y);
                    a.Update();

                }

            }

            foreach (Bullet b in bullets) {

                b.FlyToTheTarget();

            }

            foreach (IActor a in killed)             
            {
                actors.Remove(a);

            }
        }



        private void gameTimer_Tick(object sender, EventArgs e)
        {
            GameLoop();
        }
    }

    public class Bullet
    {
        public Button BulletSprite { get; set; }

        public Vector2 Acceleration { get; set; }

        public Vector2 Velocity { get; set; }

        public float MaxSpeed { get; set; }

        public Vector2 Location { get; set; }

        public Vector2 Target { get; set; }

        private int _stepCounter;

        public Bullet(Button _hunter, Vector2 location, Vector2 target)
        {
            Location = location;

            Target = target;

            Button bullet = new Button();

            bullet.Location = _hunter.Location;

            bullet.Height = 15;

            bullet.BackColor = Color.Black;

            bullet.Width = bullet.Height;

            GraphicsPath p = new GraphicsPath();

            p.AddEllipse(1, 1, bullet.Width - 4, bullet.Height - 4);

            bullet.Region = new Region(p);

            BulletSprite = bullet;

            _stepCounter = 200;

        }

        public void FlyToTheTarget() {

            if (_stepCounter > 0)

            {

                float maxspeed = 5;

                Vector2 location = Location;

                Vector2 target = Target;

                Vector2 desired = Vector2.Subtract(target, location);

                desired = Vector2.Normalize(desired);

                desired = desired * maxspeed;

                Vector2 steer = Vector2.Subtract(desired, Velocity);

                Acceleration = Acceleration + steer;

                Velocity = Velocity + Acceleration;

                //velocity.limit(maxspeed);

                location = location + Velocity;

                Location = location;

                BulletSprite.Location = new Point((int)Location.X, (int)Location.Y);

                Acceleration = Acceleration * 0;

                _stepCounter--;


            }
            else {

                BulletSprite.Dispose();

            }
            
            


        }
    
    }

}
