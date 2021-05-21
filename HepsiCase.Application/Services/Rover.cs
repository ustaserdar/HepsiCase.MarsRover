using HepsiCase.Application.Contracts;
using HepsiCase.Shared.Enums;
using HepsiCase.Shared.Exceptions;
using System;
using System.Linq;

namespace HepsiCase.Application.Services
{
    public class Rover : IRover
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Directions Direction { get; set; }
        public string Commands { get; set; }

        public void MoveForward()
        {
            switch (Direction)
            {
                case Directions.N:
                    PositionY++;
                    break;
                case Directions.E:
                    PositionX++;
                    break;
                case Directions.S:
                    PositionY--;
                    break;
                case Directions.W:
                    PositionX--;
                    break;
                default:
                    throw new DirectionException();
            }
        }

        public void SetPosition(string position)
        {
            if (
                position.Split(' ').Length != 3
                ||
                !int.TryParse(position.Split(' ')[0], out int positionX)
                ||
                !int.TryParse(position.Split(' ')[1], out int positionY)
                ||
                !Enum.GetNames(typeof(Directions)).Contains(position.Split(' ')[2])
                )
                throw new PositionException();

            PositionX = positionX;
            PositionY = positionY;
            Direction = (Directions)Enum.Parse(typeof(Directions), position.Split(' ')[2]);
        }

        public void TurnLeft()
        {
            Direction = Direction switch
            {
                Directions.N => Directions.W,
                Directions.E => Directions.N,
                Directions.S => Directions.E,
                Directions.W => Directions.S,
                _ => throw new DirectionException(),
            };
        }

        public void TurnRight()
        {
            Direction = Direction switch
            {
                Directions.N => Directions.E,
                Directions.E => Directions.S,
                Directions.S => Directions.W,
                Directions.W => Directions.N,
                _ => throw new DirectionException(),
            };
        }
    }
}
