using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BehaviorApplier
    {
        public IBehavior CurrentBehavior { get; set; }

        public SwitchCondition Condition { get; set;}

        public void ApplyBehavior(IActor behaviorPerformer) 
        {

            CurrentBehavior.Move(behaviorPerformer);

            if (Condition.Condition) {

                SwitchCondition newCondition = new SwitchCondition(!(Condition.Condition),CurrentBehavior);
                
                CurrentBehavior = Condition.NextBehavior;

                Condition = newCondition;
            
            }
        
        }
    }
}
