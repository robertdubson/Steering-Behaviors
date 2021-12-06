using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Point = System.Drawing.Point;

namespace Experiment
{
    public partial class Form1 : Form
    {
        public Button Boid { get; set; }

        Vector velocity;

        Vector acceleration;

        public Form1()
        {
            InitializeComponent();

            Button button = new Button();

            button.Height = 50;

            button.Width = button.Height;

            button.Location = new Point(500, 500);

            button.BackColor = Color.Blue;

            this.Controls.Add(button);

            Boid = button;

            velocity = new Vector(0, 0);

            acceleration = new Vector(0, 0);

            
        }

        private void GameLoop() {

            if (Boid != null) {

                //Boid.Location = Cursor.Position;

                float radius = 3;

                float maxspeed = 2;

                float maxforce = 0.1f;

                Vector location = new Vector(Boid.Location.X, Boid.Location.Y);

                float circleLength = radius * 2 * 3.1415f;

                Random rand = new Random();

                Point heighPointOfACircle = new Point(Boid.Location.X, (int)(Boid.Location.Y + radius));

                Point randomPoint = new Point();

                Vector target = new Vector((int)randomPoint.X, (int)randomPoint.Y);

                Vector desired = Vector.Subtract(target, location);

                desired.Normalize();

                desired = desired * maxspeed;

                Vector steer = Vector.Subtract(desired, velocity);

                acceleration = acceleration + steer;

                velocity = velocity + acceleration;
                
                //velocity.limit(maxspeed);
                
                location = location + velocity;

                Boid.Location = new Point((int)location.X, (int)location.Y);
                
                acceleration = acceleration * 0;

            }
            
        
        }

        private void gathering() {
        

        
        }

        private void runaway() {

            float radius = 3;

            float maxspeed = 2;

            float maxforce = 0.1f;

            Vector location = new Vector(Boid.Location.X, Boid.Location.Y);

            Vector target = new Vector(Cursor.Position.X, Cursor.Position.Y);

            Vector desired = Vector.Subtract(target, location) * -1;

            desired.Normalize();

            desired = desired * maxspeed;

            Vector steer = Vector.Subtract(desired, velocity);

            acceleration = acceleration + steer;

            velocity = velocity + acceleration;

            //velocity.limit(maxspeed);

            location = location + velocity;

            Boid.Location = new Point((int)location.X, (int)location.Y);

            acceleration = acceleration * 0;

        }

        private void seek() {

            float radius = 3;

            float maxspeed = 3;

            float maxforce = 0.1f;

            Vector location = new Vector(Boid.Location.X, Boid.Location.Y);

            Vector target = new Vector(Cursor.Position.X, Cursor.Position.Y);

            Vector desired = Vector.Subtract(target, location);

            desired.Normalize();

            desired = desired * maxspeed;

            Vector steer = Vector.Subtract(desired, velocity);

            acceleration = acceleration + steer;

            velocity = velocity + acceleration;

            //velocity.limit(maxspeed);

            location = location + velocity;

            Boid.Location = new Point((int)location.X, (int)location.Y);

            acceleration = acceleration * 0;

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            GameLoop();
        }
    }
}
