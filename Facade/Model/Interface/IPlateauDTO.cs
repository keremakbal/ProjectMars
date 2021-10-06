using Entity;
using System.Collections.Generic;

namespace Facade
{
    public interface IPlateauDTO : IPlateau
    {
        new ICollection<IRover> Rovers { get; }

    }
}
