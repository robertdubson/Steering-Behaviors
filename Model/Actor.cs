using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public class Actor : IActor
    {
        public int ID { get; set; }

        public Vector2 Acceleration { get; set; }

        public Vector2 Velocity { get; set; }

        public float MaxSpeed { get; set; }

        public Vector2 Location { get; set; }

        public GatheringField FieldOfFlow { get; set; }

        public BehaviorApplier Applier { get; set; }

        public List<IActor> Actors { get; set; }

        public int RadiusOfView { get; set; }

        public Actor(int height, int width, float maxspeed, int radius, List<IActor> actors)
        {
            Actors = actors;
            
            RadiusOfView = radius;
            
            FieldOfFlow = new GatheringField(height, width);

            Acceleration = new Vector2(0, 0);

            Velocity = new Vector2(0, 0);

            MaxSpeed = maxspeed;

            Random rand = new Random();

            int r1 = rand.Next(FieldOfFlow.Row);

            int r2 = rand.Next(FieldOfFlow.Column);

            Point location = new Point(r2 * FieldOfFlow.Resolution, r1 * FieldOfFlow.Resolution);

            Location = new Vector2((float)location.X, (float)location.Y);

            if (!Actors.Any())
            {

                ID = 1;

            }
            else { ID = Actors.Count() + 1;  }
        }

        public virtual void Update()         
        {

            Actors.Find(a => a.ID ==ID).Acceleration = this.Acceleration;

            Actors.Find(a => a.ID == ID).Location = this.Location;

            Actors.Find(a => a.ID == ID).Velocity = this.Velocity;


        }
    }
}
