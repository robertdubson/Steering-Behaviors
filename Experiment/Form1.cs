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

        GameField Field { get; set; }

        List<Animal> animals;

        public Form1()
        {
            InitializeComponent();

            this.Height = 768;

            this.Width = 1366;

            //Field = new GameField(Height, Width);

            //Button button = new Button();

            //button.Height = 20;

            //button.Width = button.Height;

            //Random rand = new Random();

            //int r1 = rand.Next(Field.Row);

            //int r2 = rand.Next(Field.Column);

            //button.Location = new Point(r2 * Field.Resolution, r1 * Field.Resolution);

            //.BackColor = Color.Blue;

            //this.Controls.Add(button);

            //Boid = button;

            velocity = new Vector(0, 0);

            acceleration = new Vector(0, 0);

            //Click += Form1_Click;

            animals = new List<Animal>();

            animals.Add(new Animal(new Button(), this, 1.15f));

            animals.Add(new Animal(new Button(), this, 1.0000000000015f));

            //GenerateBoid();
            
        }

        //private void Form1_Click(object sender, EventArgs e)
        //{
           // Boid.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
        //}

        private void GenerateBoid() {

            Button button = new Button();

            button.Height = 40;

            button.Width = button.Height;

            button.Location = new Point(500, 500);

            button.BackColor = Color.Blue;

            this.Controls.Add(button);

            Boid = button;


        } 

        private void GameLoop() {


            foreach (Animal a in animals) {

                gathering(a);               
            
            }

            //seek(animals.First(), animals.Last());
            
            //gathering(new Animal(new Button(), this, 1.23f));
 
        }

        private void gathering(Animal a) {

                float radius = 3;

                float maxspeed = a.MaxSpeed;

                float maxforce = 0.1f;

                Vector location = new Vector(a.Actor.Location.X, a.Actor.Location.Y);

                //Vector target = new Vector((int)randomPoint.X, (int)randomPoint.Y);

                //Vector target = new Vector((int)Cursor.Position.X, (int)Cursor.Position.Y);

                Vector desired = a.FieldOfFlow.Lookup(location);

                desired.Normalize();

                desired = desired * maxspeed;

                Vector steer = Vector.Subtract(desired, a.Velocity);

                acceleration = a.Acceleration + steer;

                a.Velocity = a.Velocity + acceleration;

                //velocity.limit(maxspeed);

                location = location + a.Velocity;

                a.Actor.Location = new Point((int)location.X, (int)location.Y);

                //labelPosition.Text = "( " + Boid.Location.X + ", " + Boid.Location.Y + " )";

                //Point curPoint = new Point(Boid.Location.X, Boid.Location.Y);

                //labelPointEquivalent.Text = "( " + curPoint.X + ", " + curPoint.Y + " )";

                acceleration = acceleration * 0;

                
                //Boid.Location = Cursor.Position;

                


        }

        private void coupling() 
        { 
        
        }



        private void runaway(Animal runner, Animal pursuer) {

            float radius = 3;

            float maxspeed = runner.MaxSpeed;

            float maxforce = 0.1f;

            Vector location = new Vector(runner.Actor.Location.X, runner.Actor.Location.Y);

            Vector target = new Vector(pursuer.Actor.Location.X, pursuer.Actor.Location.Y);

            Vector desired = Vector.Subtract(target, location) * -1;

            desired.Normalize();

            desired = desired * maxspeed;

            Vector steer = Vector.Subtract(desired, runner.Velocity);

            runner.Acceleration = runner.Acceleration + steer;

            runner.Velocity = runner.Velocity + runner.Acceleration;

            //velocity.limit(maxspeed);

            location = location + runner.Velocity;

            runner.Actor.Location = new Point((int)location.X, (int)location.Y);

            runner.Acceleration = runner.Acceleration * 0;

        }

        private void seek(Animal seeker, Animal targetAnimal) {

            float radius = 3;

            float maxspeed = seeker.MaxSpeed;

            float maxforce = 0.1f;

            Vector location = new Vector(seeker.Actor.Location.X, seeker.Actor.Location.Y);

            Vector target = new Vector(targetAnimal.Actor.Location.X, targetAnimal.Actor.Location.Y);

            Vector desired = Vector.Subtract(target, location);

            desired.Normalize();

            desired = desired * maxspeed;

            Vector steer = Vector.Subtract(desired, seeker.Velocity);

            seeker.Acceleration = seeker.Acceleration + steer;

            seeker.Velocity = seeker.Velocity + seeker.Acceleration;

            //velocity.limit(maxspeed);

            location = location + seeker.Velocity;

            seeker.Actor.Location = new Point((int)location.X, (int)location.Y);

            seeker.Acceleration = seeker.Acceleration * 0;

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            GameLoop();

        }

        private void Rearrenge() {

            Field = new GameField(Height, Width);
        
        }

    }

    public class GameField
    {

        public Vector[,] FieldArray { get; set; }

        public int Resolution { get; set; }

        public int Row { get; }

        public int Column { get; }

        public void Rearreange() {

            int[] directions = new int[3];

            directions[0] = -1;

            directions[1] = 0;

            directions[2] = 1;


            for (int i = 0; i < Row; i++) 
            {
                for (int j = 0; j < Column; j++) {

                    Random rand = new Random();

                    int r1 = rand.Next(3);

                    int r2 = rand.Next(3);

                    FieldArray[i, j].X = directions[r1];

                    FieldArray[i, j].Y = directions[r2];


                }
            
            
            
            }


        }

        public GameField(int Height, int Width)
        {
            Resolution = 10;

            int row = Height / Resolution;

            int column = Width / Resolution;

            Row = row;

            Column = column;

            FieldArray = new Vector[row, column];

            int[] directions = new int[3];

            directions[0] = -1;

            directions[1] = 0;

            directions[2] = 1;

            //for (int i = 0; i < column; i++) 
            //{

             //   FieldArray[0, 1] = new Vector(1, 0);

           // }
            
            for (int i = 0; i < row; i++) 
            {

                //FieldArray[i, 0] = new Vector(0, 1); 

                for (int j =0; j< column; j++) 
                {
                    Random random = new Random();

                    int r1 = random.Next(3);

                    int r2 = random.Next(3);

                    FieldArray[i, j] = new Vector(directions[r1], directions[r2]);

                    /*FieldArray[i, j] = new Vector(-1, 0);

                    if (j % 8 == 0 || j % 17 == 0 || j % 13 == 0)
                    {

                        FieldArray[i, j] = new Vector(1, 0);

                    }
                    else if (j % 6 == 0 || j % 37 ==0 || j % 41==0)
                    {

                        FieldArray[i, j] = new Vector(0, 1);

                    }
                    else if (j % 5 == 0  || j % 23==0 || j % 29==0)
                    {

                        FieldArray[i, j] = new Vector(1, 0);

                    }
                    else if (j % 7 == 0)
                    {

                        FieldArray[i, j] = new Vector(-1, 0);

                    }
                    else if (j % 11 == 0)
                    {

                        FieldArray[i, j] = new Vector(0, -1);

                    }
                    else if (j % 3 == 0) {
                        
                        FieldArray[i, j] = new Vector(-1, -1);
                    
                    }*/

                
                }

            
            }



        }

        public Vector Lookup(Vector lookup)
        {

            int row = (int)lookup.Y / Resolution;

            int column = (int)lookup.X / Resolution;

            /*if (row >= Row) {

                while (row >= Row) {

                    row -= 1;

                }
            
            }
            if (column >= Column) {

                while (column>= Column) {

                    column -= 1;
                
                }
 
            }
            if (row < 0) {

                while (row < 0)
                {

                    row += 1;

                }

            }

            if (column < 0) {

                while (column < 0)
                {

                    column += 1;

                }

            }*/

            Random r1 = new Random();

            row = r1.Next(this.Row - 1);

            column = r1.Next(this.Column - 1);

            return new Vector(FieldArray[row, column].X, FieldArray[row, column].Y);

        }



    }

    public class Animal {
    
        public Button Actor { get; set; }

        public GameField FieldOfFlow { get; set; }

        public Vector Acceleration { get; set; }

        public Vector Velocity { get; set; } 

        public float MaxSpeed { get; set; }

        public Animal(Button actor, Form1 form, float maxspeed)
        {
            Actor = actor;

            FieldOfFlow = new GameField(form.Height, form.Width);

            Acceleration = new Vector(0, 0);

            Velocity = new Vector(0, 0);

            MaxSpeed = maxspeed;

            Actor.Height = 20;

            Actor.Width = Actor.Height;

            Random rand = new Random();

            int r1 = rand.Next(FieldOfFlow.Row);

            int r2 = rand.Next(FieldOfFlow.Column);

            Actor.Location = new Point(r2 * FieldOfFlow.Resolution, r1 * FieldOfFlow.Resolution);

            Actor.BackColor = Color.Blue;

            form.Controls.Add(Actor);

        }

    
    }
}
