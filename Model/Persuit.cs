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

            BehaviorPerformer.Acceleration = BehaviorPerformer.Acceleration * 0;
        }
    }
}
