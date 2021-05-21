using HepsiCase.Application.Contracts;
using HepsiCase.Shared.Enums;
using HepsiCase.Shared.Exceptions;

namespace HepsiCase.Application.Services
{
    public class Commander : ICommander
    {
        public IPlateau Plateau { get; set; }

        public void Move(IRover rover)
        {
            var commands = rover.Commands.ToCharArray();

            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'L':
                        rover.TurnLeft();
                        break;
                    case 'R':
                        rover.TurnRight();
                        break;
                    case 'M':
                        if (CheckBoundaries(rover))
                            rover.MoveForward();
                        break;
                    default:
                        throw new CommandException();
                }
            }
        }

        private bool CheckBoundaries(IRover rover)
        {
            if (
                (rover.Direction == Directions.N && (rover.PositionY == Plateau.Height))
                ||
                (rover.Direction == Directions.S && (rover.PositionY == 0))
                ||
                (rover.Direction == Directions.E && (rover.PositionX == Plateau.Width))
                ||
                (rover.Direction == Directions.W && (rover.PositionX == 0))
                )
                throw new PlateauSizeException(rover.Direction);

            return true;
        }
    }
}
