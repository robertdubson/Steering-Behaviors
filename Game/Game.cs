using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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

        Button _hunter;

        public Game()
        {
            InitializeComponent();

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
                    sprite.Height = 30;

                    sprite.Width = sprite.Height;

                    sprite.BackColor = Color.DarkGray;

                }
                else if (a is Hare) 
                {
                    sprite.Height = 20;

                    sprite.Width = sprite.Height;

                    sprite.BackColor = Color.Gray;

                }

                a.Actors = actors;

                GraphicsPath p = new GraphicsPath();
                
                p.AddEllipse(1, 1, sprite.Width - 4, sprite.Height - 4);
                
                sprite.Region = new Region(p);

                actorsToSprites.Add(a, sprite);

                spritesToActors.Add(sprite, a);
                
                Controls.Add(sprite);

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
        }

        private void GameLoop() 
        {
            foreach (IActor a in actors) 
            {
                if (!(a is Hunter))
                {
                    a.Applier.ApplyBehavior();
                    actorsToSprites[a].Location = new Point((int)a.Location.X, (int)a.Location.Y);

                }
                else {

                    a.Location = new System.Numerics.Vector2(_hunter.Location.X, _hunter.Location.Y);

                    a.Update();

                }
                
            }
        }



        private void gameTimer_Tick(object sender, EventArgs e)
        {
            GameLoop();
        }
    }
}
