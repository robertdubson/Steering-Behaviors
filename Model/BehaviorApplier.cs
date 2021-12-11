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

        public IActor BehaviorPerformer { get; set; }

        public BehaviorApplier(IBehavior behavior, SwitchCondition condition, IActor performer)
        {
            CurrentBehavior = behavior;

            Condition = condition;

            BehaviorPerformer = performer;
        }

        public void ApplyBehavior() 
        {
            
            CurrentBehavior.Move();            

            if (Condition.Condition.Invoke()) {

                //IActor trigger = Condition.

                IActor trigger = Condition.GetTrigger();

                if (!(trigger == null))
                {

                    Condition.NextBehavior.Trigger = trigger;

                    SwitchCondition newCondition = new SwitchCondition(Condition.GetBack, Condition.Condition, CurrentBehavior, Condition.GetTrigger);

                    CurrentBehavior = Condition.NextBehavior;

                    Condition = newCondition;

                }
                else {

                    SwitchCondition newCondition = new SwitchCondition(Condition.GetBack, Condition.Condition, CurrentBehavior, Condition.GetTrigger);

                    CurrentBehavior = Condition.NextBehavior;

                    Condition = newCondition;


                }
                
                
            
            }

            BehaviorPerformer.Update();

        }
    }
}
