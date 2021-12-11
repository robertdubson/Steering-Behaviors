using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MultipleConditionBehaviorApplier : BehaviorApplier
    {
        public List<SwitchCondition> Conditions { get; set; }

        public Dictionary<bool, IBehavior> ConditionToBehavior { get; set; }
        
        public MultipleConditionBehaviorApplier(IBehavior behavior, SwitchCondition condition, IActor performer, List<SwitchCondition> coditions) : base(behavior, condition, performer)
        {
                


        }

        

    }
}
