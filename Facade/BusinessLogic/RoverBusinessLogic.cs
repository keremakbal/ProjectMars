using Domain;
using Entity;
using System.Linq;
using System.Text.RegularExpressions;

namespace Facade
{
    internal class RoverBusinessLogic : IRoverBusinessLogic
    {
        public IRoverDTO Create(IPlateauDTO plateau, string roverCoordinate)
        {
            if (plateau is null)
                throw new ValidationException("Plateau cannot be empty! Please try again.");
            if (roverCoordinate is null)
                throw new ValidationException("Rover position cannot be empty! Please try again.");

            var roverMatch = Regex.Match(roverCoordinate, RegexPatterns.RoverCoordinate, RegexOptions.Singleline);

            if (!roverMatch.Success)
                throw new ValidationException($"{roverCoordinate} is not matched.");

            var rover = new RoverDTO();
            rover.Land(plateau, new Position(int.Parse(roverMatch.Groups[1].Value), int.Parse(roverMatch.Groups[2].Value), Orientations.Items().FirstOrDefault(a => a.Key.Equals(roverMatch.Groups[3].Value.ToUpper()))));

            return rover;
        }
        public void Explore(IRoverDTO rover, string command)
        {
            if (rover is null)
                throw new ValidationException("Rover cannot be empty! Please try again.");
            if (command is null)
                throw new ValidationException("Command cannot be empty! Please try again.");

            var commandMatch = Regex.Match(command, RegexPatterns.Command, RegexOptions.Singleline);

            if (!commandMatch.Success || !commandMatch.Groups[1].Value.Equals(command))
                throw new ValidationException($"{command} is not matched.");

            var commands = command.Select(s => EnumExtension.GetMemberByValue<Command>(s.ToString().ToUpper()));
            rover.Explore(commands);
        }

    }
}
