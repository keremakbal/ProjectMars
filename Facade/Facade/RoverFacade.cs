using Domain;
using System;

namespace Facade
{
    public class RoverFacade : IRoverFacade
    {
        private static readonly Lazy<IRoverFacade> lazy = new Lazy<IRoverFacade>(() => new RoverFacade(), true);
        public static IRoverFacade Current()
        {
            return lazy.Value;
        }

        private readonly IRoverBusinessLogic _roverBusiness;
        private RoverFacade()
        {
            _roverBusiness = new RoverBusinessLogic();
        }
        public TransactionResult<IRoverDTO> Create(IPlateauDTO plateau, string roverCoordinate)
        {
            var result = new TransactionResult<IRoverDTO>();

            try
            {
                result.Response = _roverBusiness.Create(plateau, roverCoordinate);
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
        public TransactionResult Explore(IRoverDTO rover, string commandText)
        {
            var result = new TransactionResult<IRoverDTO>();

            try
            {
                _roverBusiness.Explore(rover, commandText);
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
    }
}
