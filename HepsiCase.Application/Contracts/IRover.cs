using HepsiCase.Shared.Enums;

namespace HepsiCase.Application.Contracts
{
    public interface IRover
    {
        int PositionX { get; set; }
        int PositionY { get; set; }
        Directions Direction { get; set; }
        string Commands { get; set; }

        void TurnLeft();
        void TurnRight();
        void MoveForward();
        void SetPosition(string position);
    }
}
