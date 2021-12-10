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

        public BehaviorApplier(IBehavior behavior, SwitchCondition condition)
        {
            CurrentBehavior = behavior;

            Condition = condition;
        }

        public void ApplyBehavior() 
        {
            
            CurrentBehavior.Move();

            if (Condition.Condition.Invoke()) {

                SwitchCondition newCondition = new SwitchCondition(Condition.GetBack, Condition.Condition,CurrentBehavior);
                
                CurrentBehavior = Condition.NextBehavior;

                Condition = newCondition;
            
            }
        
        }
    }
}
