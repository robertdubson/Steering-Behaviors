using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public class Persuit : IBehavior
    {
        public IActor DesiredCreature { get; set; }

        public IActor BehaviorPerformer { get; set; }

        public Vector GetDesiredMotion() {

            return (DesiredCreature.Position - BehaviorPerformer.Position) * BehaviorPerformer.SpeedLimit;

        }
    }
}
