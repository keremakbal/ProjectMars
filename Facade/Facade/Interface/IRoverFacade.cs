namespace Facade
{
    public interface IRoverFacade
    {
        TransactionResult<IRoverDTO> Create(IPlateauDTO plateau, string roverCoordinate);
        TransactionResult Explore(IRoverDTO rover, string command);
    }
}
