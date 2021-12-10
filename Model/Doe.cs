using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public class Doe : Actor, IFlocking
    {
        public float NeighbourDistance { get; set ; }
        
        public float DesiredSeparation { get; set; }

        public Doe(int height, int width, float maxspeed=15, int radius=40) : base(height, width, maxspeed, radius)
        {
            NeighbourDistance = 90;

            DesiredSeparation = 20;
            
            Func<bool> condition = ThereIsWolf;

            Func<bool> uncondition = ThereIsNoWolf;

            Func<Wolf> getDanger = GetDanger;

            SwitchCondition switchCondition = new SwitchCondition(condition, uncondition, new Runaway(this, getDanger));

            Applier = new BehaviorApplier(new Coupling(this), switchCondition);

        }

        public bool ThereIsWolf() 
        {

            return Actors.Contains(Actors.Find(w => (w is Wolf || w is Hunter) && Vector2.Distance(w.Location, this.Location)<RadiusOfView));
        
        }

        public bool ThereIsNoWolf() 
        {
            
            return Actors.Contains(Actors.Find(w => (w is Wolf || w is Hunter) && Vector2.Distance(w.Location, this.Location) < RadiusOfView));

        }

        public Wolf GetDanger() 
        {

            return (Wolf)Actors.Find(w => (w is Wolf || w is Hunter) && Vector2.Distance(w.Location, this.Location) < RadiusOfView);

        }
    }
}
