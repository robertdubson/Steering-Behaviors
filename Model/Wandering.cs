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

        public IActor Trigger { get; set; }

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

            Limit(Wanderer);

            Wanderer.Acceleration = Wanderer.Acceleration * 0;
        }

        public void ApplyLimitations() {

            while (Wanderer.Location.X < 70)
            {

                Wanderer.Location = new Vector2(Wanderer.Location.X + 1, Wanderer.Location.Y); 

            }
            while (Wanderer.Location.Y > 681)
            {

                Wanderer.Location = new Vector2(Wanderer.Location.X, Wanderer.Location.Y-5);

            }
            while (Wanderer.Location.X > 1289)
            {

                Wanderer.Location = new Vector2(Wanderer.Location.X - 1, Wanderer.Location.Y);

            }
            while (Wanderer.Location.Y < 65)
            {

                Wanderer.Location = new Vector2(Wanderer.Location.X, Wanderer.Location.Y + 5);

            }

        }

        public void Limit(IActor whoToLimit)
        {

            while (whoToLimit.Location.X < 70)
            {

                whoToLimit.Location = new Vector2(whoToLimit.Location.X + 1, whoToLimit.Location.Y);

            }
            while (whoToLimit.Location.Y > 681)
            {

                whoToLimit.Location = new Vector2(whoToLimit.Location.X, whoToLimit.Location.Y - 1);

            }
            while (whoToLimit.Location.X > 1989)
            {

                whoToLimit.Location = new Vector2(whoToLimit.Location.X - 1, whoToLimit.Location.Y);

            }
            while (whoToLimit.Location.Y < 65)
            {

                whoToLimit.Location = new Vector2(whoToLimit.Location.X, whoToLimit.Location.Y + 1);

            }


        }

    }
}
