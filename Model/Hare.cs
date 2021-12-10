using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public class Hare : Actor
    {
        public Hare(int height, int width, float maxspeed=5, int radius=10) : base(height, width, maxspeed, radius)
        {
            Func<bool> condition = IsThereDangerCreature;

            Func<bool> uncondition = ThereIsNoDanger;

            Func<IActor> getDanger = GetTheDanger;

            SwitchCondition switchCondition = new SwitchCondition(condition, uncondition, new Runaway(this, getDanger));

            Applier = new BehaviorApplier(new Wandering(this), switchCondition);
        
        }

        public bool IsThereDangerCreature() 
        {

            return Actors.Contains(Actors.Find(h => Vector2.Distance(this.Location, h.Location)<RadiusOfView));
        
        }

        public bool ThereIsNoDanger() 
        {

            return !Actors.Contains(Actors.Find(h => Vector2.Distance(this.Location, h.Location) < RadiusOfView));

        }

        public IActor GetTheDanger() 
        {

            return Actors.Find(h => Vector2.Distance(this.Location, h.Location) < RadiusOfView);


        }


    }
}
