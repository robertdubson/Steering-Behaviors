using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
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

        Vector2 velocity;

        Vector2 acceleration;

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

            velocity = new Vector2(0, 0);

            acceleration = new Vector2(0, 0);

            Click += Form1_Click; ;

            animals = new List<Animal>();

            //animals.Add(new Animal(new Button(), this, 1.15f));

            //animals.Add(new Animal(new Button(), this, 1.0000000000015f));



            //GenerateBoid();

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            animals.Add(new Animal(new Button(), this, 1.0000000000015f, Cursor.Position.X, Cursor.Position.Y));
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
                a.flock(animals);
            }

            //seek(animals.First(), animals.Last());
            
            //gathering(new Animal(new Button(), this, 1.23f));
 
        }

        private void gathering(Animal a) {

                float radius = 3;

                float maxspeed = a.MaxSpeed;

                float maxforce = 0.1f;

                Vector2 location = new Vector2(a.Actor.Location.X, a.Actor.Location.Y);

                //Vector target = new Vector((int)randomPoint.X, (int)randomPoint.Y);

                //Vector target = new Vector((int)Cursor.Position.X, (int)Cursor.Position.Y);

                Vector2 desired = a.FieldOfFlow.Lookup(location);

                desired = Vector2.Normalize(desired);

                desired = desired * maxspeed;

                Vector2 steer = Vector2.Subtract(desired, a.Velocity);

                a.Acceleration = a.Acceleration + steer;

                a.Velocity = a.Velocity + a.Acceleration;

                //velocity.limit(maxspeed);

                location = location + a.Velocity;

                a.Actor.Location = new Point((int)location.X, (int)location.Y);

                a.Location = location;

                //labelPosition.Text = "( " + Boid.Location.X + ", " + Boid.Location.Y + " )";

                //Point curPoint = new Point(Boid.Location.X, Boid.Location.Y);

                //labelPointEquivalent.Text = "( " + curPoint.X + ", " + curPoint.Y + " )";

                a.Acceleration = a.Acceleration * 0;

                
                //Boid.Location = Cursor.Position;

                


        }



        private void coupling() 
        { 
        
        }



        private void runaway(Animal runner, Animal pursuer) {

            float radius = 3;

            float maxspeed = runner.MaxSpeed;

            float maxforce = 0.1f;

            Vector2 location = new Vector2(runner.Actor.Location.X, runner.Actor.Location.Y);

            Vector2 target = new Vector2(pursuer.Actor.Location.X, pursuer.Actor.Location.Y);

            Vector2 desired = Vector2.Subtract(target, location) * -1;

            desired = Vector2.Normalize(desired);

            desired = desired * maxspeed;

            Vector2 steer = Vector2.Subtract(desired, runner.Velocity);

            runner.Acceleration = runner.Acceleration + steer;

            runner.Velocity = runner.Velocity + runner.Acceleration;

            //velocity.limit(maxspeed);

            location = location + runner.Velocity;

            runner.Actor.Location = new Point((int)location.X, (int)location.Y);

            runner.Location = location;

            runner.Acceleration = runner.Acceleration * 0;

        }

        private void seek(Animal seeker, Animal targetAnimal) {

            float radius = 3;

            float maxspeed = seeker.MaxSpeed;

            float maxforce = 0.1f;

            Vector2 location = new Vector2(seeker.Actor.Location.X, seeker.Actor.Location.Y);

            Vector2 target = new Vector2(targetAnimal.Actor.Location.X, targetAnimal.Actor.Location.Y);

            Vector2 desired = Vector2.Subtract(target, location);

            desired = Vector2.Normalize(desired);

            desired = desired * maxspeed;

            Vector2 steer = Vector2.Subtract(desired, seeker.Velocity);

            seeker.Acceleration = seeker.Acceleration + steer;

            seeker.Velocity = seeker.Velocity + seeker.Acceleration;

            //velocity.limit(maxspeed);

            location = location + seeker.Velocity;

            seeker.Actor.Location = new Point((int)location.X, (int)location.Y);

            seeker.Location = location;

            seeker.Acceleration = seeker.Acceleration * 0;

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            GameLoop();
            labelPosition.Text = Cursor.Position.X + " " + Cursor.Position.Y;
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

        public Vector2 Lookup(Vector2 lookup)
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

            return new Vector2((float)FieldArray[row, column].X, (float)FieldArray[row, column].Y);

        }



    }

    public class Animal {
    
        public Button Actor { get; set; }

        public GameField FieldOfFlow { get; set; }

        public Vector2 Acceleration { get; set; }

        public Vector2 Velocity { get; set; } 

        public float MaxSpeed { get; set; }

        public Vector2 Location { get; set; }

        public Animal(Button actor, Form1 form, float maxspeed, int x, int y)
        {
            Actor = actor;

            FieldOfFlow = new GameField(form.Height, form.Width);

            Acceleration = new Vector2(0, 0);

            Velocity = new Vector2(0, 0);

            MaxSpeed = maxspeed;

            Actor.Height = 20;

            Actor.Width = Actor.Height;

            Actor.Location = new Point(x, y);

            Location = new Vector2(Actor.Location.X, Actor.Location.Y);

            Actor.BackColor = Color.Blue;

            form.Controls.Add(Actor);

        }

        public Animal(Button actor, Form1 form, float maxspeed)
        {
            Actor = actor;

            FieldOfFlow = new GameField(form.Height, form.Width);

            Acceleration = new Vector2(0, 0);

            Velocity = new Vector2(0, 0);

            MaxSpeed = maxspeed;

            Actor.Height = 20;

            Actor.Width = Actor.Height;

            Random rand = new Random();

            int r1 = rand.Next(FieldOfFlow.Row);

            int r2 = rand.Next(FieldOfFlow.Column);

            Actor.Location = new Point(r2 * FieldOfFlow.Resolution, r1 * FieldOfFlow.Resolution);

            Location = new Vector2(Actor.Location.X, Actor.Location.Y);

            Actor.BackColor = Color.Blue;

            form.Controls.Add(Actor);

        }

        public void flock(List<Animal> animals) 
        {
            separate(animals);
            align(animals);
            coh(animals);
        
        }

        public void coh(List<Animal> animals) {

            float neighbordist = 90f;

            Vector2 sum = new Vector2(0, 0);

            int count = 0;

            foreach (Animal a in animals) 
            {

                float dist = Vector2.Distance(this.Location, a.Location);

                if ((dist>0) && (dist < neighbordist)) 
                {
                    sum += a.Location;
                    count++;
                
                }
            
            }
            if (count > 0) 
            {
                sum /= count;

                Vector2 desired = sum;

                desired = Vector2.Normalize(desired);

                desired = desired * this.MaxSpeed;

                Vector2 steer = Vector2.Subtract(desired, this.Velocity);

                this.Acceleration = this.Acceleration + steer;

                this.Velocity = this.Velocity + this.Acceleration;

                //velocity.limit(maxspeed);

                this.Location = this.Location + this.Velocity;

                this.Actor.Location = new Point((int)this.Location.X, (int)this.Location.Y);

                //this.Location = this.Actor.Location;

                //this.Acceleration = this.Acceleration * 0;

            }
        
        
        }

        public void align(List<Animal> animals) 
        {

            float neighbordist = 90f;

            int count = 0;

            Vector2 sum = new Vector2();
            
            foreach (Animal a in animals) {

                float distance = Vector2.Distance(this.Location, a.Location);
                if ((distance>0) && (distance<neighbordist)) {

                    sum += a.Velocity;
                    count++;
                }                

            }
            if (count>0) 
            {

                sum /= animals.Count();

                sum = Vector2.Normalize(sum);

                sum *= this.MaxSpeed;

                Vector2 steer = Vector2.Subtract(sum, this.Velocity);

                this.Acceleration += steer;

                this.Velocity += this.Acceleration;

                //velocity.limit(maxspeed);

                this.Location = this.Location + this.Velocity;

                this.Actor.Location = new Point((int)this.Location.X, (int)this.Location.Y);

                //this.Acceleration = this.Acceleration * 0;
            }

        }

        public void separate(List<Animal> animals) {

            float desiredseparation = 20f;

            //float desiredseparation = 10 * this.Actor.Width;

            Vector2 sum = new Vector2();

            int count = 0;
            
            foreach (Animal a in animals) 
            {
                if (a!=this) 
                {
                    float distance = Vector2.Distance(this.Location, a.Location);

                    if ((distance > 0) && (distance < desiredseparation))
                    {
                        Vector2 diff = Vector2.Subtract(this.Location, a.Location);
                        diff = Vector2.Normalize(diff);
                        //diff /= distance;
                        sum += diff;
                        count++;
                    }


                }
            
            }
            if (count>0) 
            {

                sum /= count;

                Vector2 steer = Vector2.Subtract(sum, this.Velocity);

                this.Acceleration += steer;

                this.Velocity += this.Acceleration;

                //velocity.limit(maxspeed);

                this.Location = this.Location + this.Velocity;

                this.Actor.Location = new Point((int)this.Location.X, (int)this.Location.Y);

                //this.Acceleration = this.Acceleration * 0;
            }
        
        }
    
    }
}
