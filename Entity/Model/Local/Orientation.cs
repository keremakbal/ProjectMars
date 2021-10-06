using System;
namespace Entity
{
    internal class Orientation : IOrientation
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public int AxisX { get; set; }
        public int AxisY { get; set; }
        public int Angle { get; set; }
    }
}
