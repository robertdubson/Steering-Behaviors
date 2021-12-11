using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public class Runaway : IBehavior
    {

        public IActor Trigger { get; set; }

        public IActor Runner { get; set; }

        public IActor Persuer { get; set; }

        public Func<IActor> GetPersuer { get; set; }

        public Runaway(IActor runner, IActor persuer)
        {
            Runner = runner;

            Persuer = persuer;
        }

        public Runaway(IActor runner, Func<IActor> getPersuer)
        {
            GetPersuer = getPersuer;

            Runner = runner;

        }


        public void Move()
        {            

            float maxspeed = Runner.MaxSpeed;

            Persuer = GetPersuer.Invoke();

            if (Persuer==null) {

                Persuer = Trigger;

            }

            Vector2 location = new Vector2(Runner.Location.X, Runner.Location.Y);

            Vector2 target = new Vector2(Persuer.Location.X, Persuer.Location.Y);

            Vector2 desired = Vector2.Subtract(target, location) * -1;

            desired = Vector2.Normalize(desired);

            desired = desired * maxspeed;

            Vector2 steer = Vector2.Subtract(desired, Runner.Velocity);

            Runner.Acceleration = Runner.Acceleration + steer;

            Runner.Velocity = Runner.Velocity + Runner.Acceleration;

            //velocity.limit(maxspeed);

            location = location + Runner.Velocity;

            Runner.Location = location;

            Runner.Acceleration = Runner.Acceleration * 0;

        }
    }
}
