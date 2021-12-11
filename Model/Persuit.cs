using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public class Persuit : IBehavior
    {
        public IActor DesiredCreature { get; set; }

        public IActor Trigger { get; set; }

        public IActor BehaviorPerformer { get; set; }

        public Func<IActor> GetTarget { get; set; }

        public Persuit(IActor seeker, IActor target)
        {
            DesiredCreature = target;

            BehaviorPerformer = seeker;
        }

        public Persuit(IActor seeker, Func<IActor> getTarget)
        {
            GetTarget = getTarget;

            BehaviorPerformer = seeker;

        }

        public void Move()
        {
            DesiredCreature = GetTarget.Invoke();

            if (DesiredCreature ==null) {

                DesiredCreature = Trigger;

            }
            

            float maxspeed = BehaviorPerformer.MaxSpeed;

            Vector2 location = new Vector2(BehaviorPerformer.Location.X, BehaviorPerformer.Location.Y);

            Vector2 target = new Vector2(DesiredCreature.Location.X, DesiredCreature.Location.Y);

            Vector2 desired = Vector2.Subtract(target, location);

            desired = Vector2.Normalize(desired);

            desired = desired * maxspeed;

            Vector2 steer = Vector2.Subtract(desired, BehaviorPerformer.Velocity);

            BehaviorPerformer.Acceleration = BehaviorPerformer.Acceleration + steer;

            BehaviorPerformer.Velocity = BehaviorPerformer.Velocity + BehaviorPerformer.Acceleration;

            //velocity.limit(maxspeed);

            location = location + BehaviorPerformer.Velocity;

            BehaviorPerformer.Location = location;

            Limit(BehaviorPerformer);

            BehaviorPerformer.Acceleration = BehaviorPerformer.Acceleration * 0;
        }

        public void ApplyLimitations()
        {

            while (BehaviorPerformer.Location.X < 70)
            {

                BehaviorPerformer.Location = new Vector2(BehaviorPerformer.Location.X + 1, BehaviorPerformer.Location.Y);

            }
            while (BehaviorPerformer.Location.Y > 681)
            {

                BehaviorPerformer.Location = new Vector2(BehaviorPerformer.Location.X, BehaviorPerformer.Location.Y - 1);

            }
            while (BehaviorPerformer.Location.X > 1289)
            {

                BehaviorPerformer.Location = new Vector2(BehaviorPerformer.Location.X - 1, BehaviorPerformer.Location.Y);

            }
            while (BehaviorPerformer.Location.Y < 65)
            {

                BehaviorPerformer.Location = new Vector2(BehaviorPerformer.Location.X, BehaviorPerformer.Location.Y + 1);

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

                whoToLimit.Location = new Vector2(whoToLimit.Location.X, whoToLimit.Location.Y - 5);

            }
            while (whoToLimit.Location.X > 1989)
            {

                whoToLimit.Location = new Vector2(whoToLimit.Location.X - 1, whoToLimit.Location.Y);

            }
            while (whoToLimit.Location.Y < 65)
            {

                whoToLimit.Location = new Vector2(whoToLimit.Location.X, whoToLimit.Location.Y + 5);

            }


        }


    }
}
