namespace Facade
{
    internal interface IRoverBusinessLogic
    {
        IRoverDTO Create(IPlateauDTO plateau, string roverCoordinate);
        void Explore(IRoverDTO rover, string command);
    }
}
