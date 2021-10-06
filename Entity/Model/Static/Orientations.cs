using System.Collections.Generic;

namespace Entity
{
    public static class Orientations
    {
        public static IOrientation North()
        {
            return new Orientation { Key = "N", Name = "North", AxisX = 0, AxisY = +1, Angle = 0 };
        }
        public static IOrientation East()
        {
            return new Orientation { Key = "E", Name = "East", AxisX = +1, AxisY = 0, Angle = 90 };
        }
        public static IOrientation South()
        {
            return new Orientation { Key = "S", Name = "South", AxisX = 0, AxisY = -1, Angle = 180 };
        }
        public static IOrientation West()
        {
            return new Orientation { Key = "W", Name = "West", AxisX = -1, AxisY = 0, Angle = 270 };
        }
        public static IReadOnlyCollection<IOrientation> Items()
        {
            return new HashSet<IOrientation> { North(), East(), South(), West() };
        }
    }
}
