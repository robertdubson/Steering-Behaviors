using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public class Wolf : Actor
    {
        public Wolf(int height, int width, float maxspeed=4, int radius=30) : base(height, width, maxspeed, radius)
        {


            Func<bool> findHare = SearchForClosestHare;

            Func<bool> stopSearchHare = UnfindHare;

            Func<IActor> getHare = DetermineTheHare;
            
            SwitchCondition condition = new SwitchCondition(findHare, stopSearchHare, new Persuit(this, getHare));
            
            Applier = new BehaviorApplier(new Wandering(this), condition);

        }

        private bool UnfindHare() {

            return !Actors.Contains(Actors.Find(h => (h is Hare) && (Vector2.Distance(this.Location, h.Location) < RadiusOfView)));

        }

        private bool SearchForClosestHare() {

            return Actors.Contains(Actors.Find(h => (h is Hare) && (Vector2.Distance(this.Location, h.Location) < RadiusOfView)));

        }

        private Hare DetermineTheHare() {

            return (Hare)Actors.Find(h => (h is Hare) && (Vector2.Distance(this.Location, h.Location) < RadiusOfView));

        }
    }
}
