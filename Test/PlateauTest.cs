using Microsoft.VisualStudio.TestTools.UnitTesting;
using Facade;

namespace Test
{
    [TestClass]
    public class PlateauTest
    {
        private IPlateauDTO plateauDTO;

        [TestInitialize]
        public void Initialize()
        {
            plateauDTO = null;
        }

        [TestMethod("Create Plateau")]
        [DataRow("5 5", DisplayName = "Plateau width and height")]
        public void IsPlateauCreate(string plateauSizeText)
        {
            var plateauServiceResult = PlateauFacade.Current().Create(plateauSizeText);
            plateauDTO = plateauServiceResult.Response;
            Assert.IsTrue(plateauServiceResult.IsSuccess, plateauServiceResult.Message);
        }

        [TestMethod("Create Plateau Display Text")]
        public void IsDisplayTextCreate()
        {
            IsPlateauCreate("5 5");
            var plateauServiceResult = PlateauFacade.Current().MissionResult(plateauDTO, "L");
            Assert.IsTrue(plateauServiceResult.IsSuccess, plateauServiceResult.Message);
            Assert.IsFalse(string.IsNullOrWhiteSpace(plateauServiceResult.Response), "Display text is empty or null");
        }

        [TestMethod("Validation Plateau")]
        [DataRow("55", DisplayName = "Plateau width and height wrong!")]
        public void HandleValidationException(string plateauSizeText)
        {
            var plateauServiceResult = PlateauFacade.Current().Create(plateauSizeText);
            Assert.IsFalse(plateauServiceResult.IsSuccess, plateauServiceResult.Message);
            Assert.AreEqual(plateauServiceResult.Message, $"{plateauSizeText} is not matched.");
        }
    }
}
