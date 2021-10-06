using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Entity
{
    public class Rover : IRover
    {
        public Position Position { get; private set; }
        public IPlateau Plateau { get; private set; }

        public void Land(IPlateau plateau, Position position)
        {
            if (plateau is null)
                throw new ValidationException("Plateau is not null!");
            if (position is null)
                throw new ValidationException("Rover position is not null!");
            if (plateau.AxisX < position.AxisX)
                throw new ValidationException("Plato's X coordinate cannot be less than the X coordinate that Rover will land!");
            if (plateau.AxisY < position.AxisY)
                throw new ValidationException("Plato's Y coordinate cannot be less than the Y coordinate that Rover will land!");
            if (position.AxisX < 0)
                throw new ValidationException("Rover's X coordinate cannot be less than 0!");
            if (position.AxisY < 0)
                throw new ValidationException("Rover's Y coordinate cannot be less than 0!");

            Plateau = plateau;
            Plateau.AddRover(this);
            Position = position;
        }

        public void Explore(IEnumerable<Command> commands)
        {
            if (commands is null)
                throw new ValidationException("Commands is not null!");
            if (!commands.Any())
                throw new ValidationException("Commands is not empty!");

            Position currentPosition = (Position)Position.Clone();

            try
            {
                foreach (var command in commands)
                {

                    switch (command)
                    {
                        case Command.Left:
                            TurnLeft(1);
                            break;
                        case Command.Right:
                            TurnRight(1);
                            break;
                        case Command.Move:
                            Move(1);
                            break;
                    }
                }
            }
            catch (ValidationException ex)
            {
                Position = currentPosition;
#pragma warning disable CA2200 // Rethrow to preserve stack details
                throw ex;
#pragma warning restore CA2200 // Rethrow to preserve stack details
            }
        }

        public void Move(int count)
        {
            if (Plateau.AxisX < Position.AxisX + (count * Position.Orientation.AxisX))
                throw new ValidationException("Rover's X coordinate cannot be less than the plateau's X coordinate!");
            if (Position.AxisX + (count * Position.Orientation.AxisX) < 0)
                throw new ValidationException("Rover's X coordinate cannot be less than 0!");
            if (Plateau.AxisY < Position.AxisY + (count * Position.Orientation.AxisY))
                throw new ValidationException("Rover's Y coordinate cannot be less than the plateau's Y coordinate!");
            if (Position.AxisY + (count * Position.Orientation.AxisY) < 0)
                throw new ValidationException("Rover's Y coordinate cannot be less than 0!");

            Position.AxisX += count * Position.Orientation.AxisX;
            Position.AxisY += count * Position.Orientation.AxisY;
        }

        public void TurnLeft(int count)
        {
            Turn(-90 * count);
        }

        public void TurnRight(int count)
        {
            Turn(90 * count);
        }

        private void Turn(int degree)
        {
            int angle = ((360 + (Position.Orientation.Angle + degree)) % 360);

            var newDirection = Orientations.Items().FirstOrDefault(a => a.Angle.Equals(angle));
            if (newDirection is null)
                throw new ValidationException("It's not a right angle");

            Position.Orientation = newDirection;
        }
    }
}
