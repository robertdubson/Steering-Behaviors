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
        public Hare(int height, int width, List<IActor> actors, float maxspeed=3, int radius=10) : base(height, width, maxspeed, radius, actors)
        {
            Func<bool> condition = IsThereDangerCreature;

            Func<bool> uncondition = ThereIsNoDanger;

            Func<IActor> getDanger = GetTheDanger;

            SwitchCondition switchCondition = new SwitchCondition(condition, uncondition, new Runaway(this, getDanger), getDanger);

            Applier = new BehaviorApplier(new Wandering(this), switchCondition, this);
        
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
