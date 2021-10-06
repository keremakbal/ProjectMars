using System.Collections.Generic;

namespace Entity
{
    public interface IPlateau
    {
        int AxisX { get; }
        int AxisY { get; }

        ICollection<IRover> Rovers { get; }

        void AddRover(IRover rover);
    }
}
