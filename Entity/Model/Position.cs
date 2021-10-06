using System;

namespace Entity
{
    public class Position : ICloneable
    {
        public Position(int axisX, int axisY, IOrientation orientation)
        {
            AxisX = axisX; AxisY = axisY; Orientation = orientation;
        }

        public int AxisX { get; set; }
        public int AxisY { get; set; }
        public IOrientation Orientation { get; set; }

        public object Clone()
        {
            return new Position(AxisX, AxisY, Orientation);
        }
        public override string ToString()
        {
            return $"{AxisX} {AxisY} {Orientation.Key}";
        }
    }
}
