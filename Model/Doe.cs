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

        public Doe(int height, int width, List<IActor> actors, float maxspeed=1.8f, int radius=180) : base(height, width, maxspeed, radius, actors)
        {
            NeighbourDistance = 90;

            DesiredSeparation = 20;
            
            Func<bool> condition = ThereIsWolf;

            Func<bool> uncondition = ThereIsNoWolf;

            Func<IActor> getDanger = GetDanger;

            SwitchCondition switchCondition = new SwitchCondition(condition, uncondition, new Runaway(this, getDanger), getDanger);

            Applier = new BehaviorApplier(new Coupling(this), switchCondition, this);

        }

        public bool ThereIsWolf() 
        {

            return Actors.Contains(Actors.Find(w => (w is Wolf || w is Hunter) && Vector2.Distance(w.Location, this.Location)<RadiusOfView));
        
        }

        public bool ThereIsNoWolf() 
        {
            
            return Actors.Contains(Actors.Find(w => (w is Wolf || w is Hunter) && Vector2.Distance(w.Location, this.Location) < RadiusOfView));

        }

        public IActor GetDanger() 
        {

            return Actors.Find(w => (w is Wolf || w is Hunter) && Vector2.Distance(w.Location, this.Location) < RadiusOfView);

        }
    }
}
