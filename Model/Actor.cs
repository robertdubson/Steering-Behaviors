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
        public Vector2 Acceleration { get; set; }

        public Vector2 Velocity { get; set; }

        public float MaxSpeed { get; set; }

        public Vector2 Location { get; set; }

        public GatheringField FieldOfFlow { get; set; }

        public BehaviorApplier Applier { get; set; }

        public List<IActor> Actors { get; set; }

        public int RadiusOfView { get; set; }

        public Actor(int height, int width, float maxspeed, int radius)
        {
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
        }
    }
}
