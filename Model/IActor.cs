using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public interface IActor
    {
        Point Position { get; set; }

        float SpeedLimit { get; set; }
    }
}
