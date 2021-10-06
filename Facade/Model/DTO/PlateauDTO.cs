using Entity;

namespace Facade
{
    internal class PlateauDTO : Plateau, IPlateauDTO
    {
        public PlateauDTO(int axisX, int axisY) : base(axisX, axisY)
        {
        }
    }
}
