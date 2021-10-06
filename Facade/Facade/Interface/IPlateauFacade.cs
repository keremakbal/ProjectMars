namespace Facade
{
    public interface IPlateauFacade
    {
        TransactionResult<IPlateauDTO> Create(string coordinate);
        TransactionResult<string> MissionResult(IPlateauDTO plateau, string missionType);
    }
}
