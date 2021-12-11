using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SwitchCondition
    {
        public Func<bool> Condition;

        public Func<bool> GetBack;

        public Func<IBehavior> GetNextBehavior;

        public Func<IActor> GetTrigger;

        public IBehavior NextBehavior { get; set; }

        public SwitchCondition(Func<bool> conditionOfChange, Func<bool> condidtionOfReturn, IBehavior behavior, Func<IActor> getTrigger)
        {
            Condition = conditionOfChange;

            GetBack = condidtionOfReturn;

            GetTrigger = getTrigger;

            //GetNextBehavior = getBehavior;

            NextBehavior = behavior;
        }

    }
}
