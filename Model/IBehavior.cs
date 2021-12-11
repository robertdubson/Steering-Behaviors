using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public interface IBehavior
    {
        IActor Trigger { get; set; }        

        void Limit(IActor whoToLimit);

        void Move();
    }
}
