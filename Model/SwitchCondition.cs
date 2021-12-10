using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SwitchCondition
    {
        public bool Condition { get; set; }

        public IBehavior NextBehavior { get; set; }

        public SwitchCondition(bool condition, IBehavior behavior)
        {
            Condition = condition;

            NextBehavior = behavior;
        }

    }
}
