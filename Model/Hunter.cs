using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Hunter : IActor
    {
        public int ID { get; set; }
        public Vector2 Acceleration { get ;set ; }
        public Vector2 Velocity { get ; set ; }
        public float MaxSpeed { get ; set ; }
        public Vector2 Location { get ; set ; }
        public GatheringField FieldOfFlow { get ; set ; }
        public BehaviorApplier Applier { get  ; set ; }
        public int RadiusOfView { get  ; set ; }
        public List<IActor> Actors { get ; set ; }

        public int BulletCounter { get; set; }

        public Hunter(List<IActor> actors)
        {
            BulletCounter = 20;

            Actors = actors;

            if (!Actors.Any())
            {

                ID = 1;

            }
            else { ID = Actors.Count() + 1; }
        }

        public void Update()
        {            

            Actors.Find(a => a.ID == ID).Location = this.Location;
 
        }
    }
}
