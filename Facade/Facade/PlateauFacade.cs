using Domain;
using Entity;
using System;
using System.Linq;
using System.Text;

namespace Facade
{
    public class PlateauFacade : IPlateauFacade
    {
        private static readonly Lazy<IPlateauFacade> lazy = new Lazy<IPlateauFacade>(() => new PlateauFacade(), true);
        public static IPlateauFacade Current()
        {
            return lazy.Value;
        }

        private readonly IPlateauBusinessLogic _plateauBusiness;
        private PlateauFacade()
        {
            _plateauBusiness = new PlateauBusinessLogic();
        }
        public TransactionResult<IPlateauDTO> Create(string coordinate)
        {
            var result = new TransactionResult<IPlateauDTO>();

            try
            {
                result.Response = _plateauBusiness.Create(coordinate);
                result.SetStatusSucceeded("Transaction succeed.");
            }
            catch (ValidationException ve)
            {
                result.SetStatusValidationException(ve.Message);
            }
            catch (Exception ex)
            {
                result.SetStatusUnhandledException(ex);
            }

            return result;
        }
        public TransactionResult<string> MissionResult(IPlateauDTO plateau, string missionType)
        {
            var missionTypes = missionType.Select(s => EnumExtension.GetMemberByValue<MissionType>(s.ToString().ToUpper())).FirstOrDefault();

            var result = new TransactionResult<string>();
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var rover in plateau.Rovers)
            {
                switch (missionTypes)
                {
                    case MissionType.Landing:
                        stringBuilder.AppendLine($"Landing mission completed. Landing coordinate: {rover.Position}");
                        break;
                    case MissionType.Discover:
                        stringBuilder.AppendLine($"Discovery mission completed. discovered coordinate: {rover.Position}");
                        break;
                }

            }

            result.Response = stringBuilder.ToString();
            stringBuilder = null;
            result.SetStatusSucceeded("Transaction succeed.");
            return result;
        }
    }
}
