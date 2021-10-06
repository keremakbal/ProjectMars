using System.Collections.Generic;

namespace Entity
{
    public interface IRover
    {
        IPlateau Plateau { get; }
        Position Position { get; }

        void Land(IPlateau plateau, Position position);
        void TurnLeft(int count);
        void TurnRight(int count);
        void Move(int count);
        void Explore(IEnumerable<Command> commands);
    }
}
