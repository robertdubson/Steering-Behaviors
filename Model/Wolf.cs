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
        public int Satiety { get; set; }

        public Wolf(int height, int width, List<IActor> actors, float maxspeed=1.35f, int radius=30) : base(height, width, maxspeed, radius, actors)
        {
            Satiety = 100;

            Func<bool> findHare = SearchForClosestHare;

            Func<bool> stopSearchHare = UnfindHare;

            Func<IActor> getHare = DetermineTheVictim;
            
            SwitchCondition condition = new SwitchCondition(findHare, stopSearchHare, new Persuit(this, getHare), getHare);
            
            Applier = new BehaviorApplier(new Wandering(this), condition, this);

        }

        private bool UnfindHare() {

            return !Actors.Contains(Actors.Find(h => ((h is Hare) || (h is Doe)) && (Vector2.Distance(this.Location, h.Location) < RadiusOfView)));

        }

        private bool SearchForClosestHare() {

            return Actors.Contains(Actors.Find(h => ((h is Hare) || (h is Doe)) && (Vector2.Distance(this.Location, h.Location) < RadiusOfView)));

        }

        private IActor DetermineTheVictim() {

            return Actors.Find(h => ((h is Hare) || (h is Doe)) && (Vector2.Distance(this.Location, h.Location) < RadiusOfView));

        }
    }
}
