using Domain;
using System.Text.RegularExpressions;

namespace Facade
{
    internal class PlateauBusinessLogic : IPlateauBusinessLogic
    {
        public IPlateauDTO Create(string coordinate)
        {
            if (coordinate is null)
                throw new ValidationException($"Coordinate information cannot be empty! Please try again.");

            var match = Regex.Match(coordinate, RegexPatterns.PlateauCoordinate, RegexOptions.Singleline);

            if (match.Success)
                return new PlateauDTO(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));

            throw new ValidationException($"{coordinate} is not matched.");
        }
    }
}
