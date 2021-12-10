using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public class Wandering : IBehavior
    {
        public IActor Wanderer { get; set; }

        public Wandering(IActor wanderer)
        {
            Wanderer = wanderer;
        }

        public void Move()
        {
            float maxspeed = Wanderer.MaxSpeed;

            Vector2 location = new Vector2(Wanderer.Location.X, Wanderer.Location.Y);

            Vector2 desired = Wanderer.FieldOfFlow.Lookup(location);

            desired = Vector2.Normalize(desired);

            desired = desired * maxspeed;

            Vector2 steer = Vector2.Subtract(desired, Wanderer.Velocity);

            Wanderer.Acceleration = Wanderer.Acceleration + steer;

            Wanderer.Velocity = Wanderer.Velocity + Wanderer.Acceleration;

            location = location + Wanderer.Velocity;

            Wanderer.Location = location;

            Wanderer.Acceleration = Wanderer.Acceleration * 0;
        }
    }
}
