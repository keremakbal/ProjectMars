using System.Collections.Generic;

namespace Entity
{
    public class Plateau : IPlateau
    {
        public Plateau(int axisX, int axisY)
        {
            AxisX = axisX;
            AxisY = axisY;
            Rovers = new HashSet<IRover>();
        }
        public int AxisX { get; private set; }
        public int AxisY { get; private set; }

        public ICollection<IRover> Rovers { get; }

        public void AddRover(IRover rover)
        {
            Rovers.Add(rover);
        }
    }
}
