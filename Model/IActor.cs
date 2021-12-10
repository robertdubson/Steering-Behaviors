using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    public interface IActor
    {
        Vector2 Acceleration { get; set; }

        Vector2 Velocity { get; set; }

        float MaxSpeed { get; set; }

        Vector2 Location { get; set; }

        GatheringField FieldOfFlow { get; set; }

        BehaviorApplier Applier { get; set; }

        int RadiusOfView { get; set; }

        List<IActor> Actors { get; set; }
    }
}
