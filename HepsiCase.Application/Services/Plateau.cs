using HepsiCase.Application.Contracts;
using HepsiCase.Shared.Exceptions;
using System;
using System.Collections.Generic;

namespace HepsiCase.Application.Services
{
    public class Plateau : IPlateau
    {
        public IList<IRover> Rovers { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Plateau()
        {
            Rovers = new List<IRover>();
        }

        public void AddRover(IRover rover)
        {
            if (rover.PositionX > Width || rover.PositionY > Height)
                throw new PlateauSizeException();

            Rovers.Add(rover);
        }

        public void SetSize(string size)
        {
            if (
                size.Split(' ').Length != 2 
                || 
                !int.TryParse(size.Split(' ')[0], out int width) 
                || 
                !int.TryParse(size.Split(' ')[1], out int height) 
                || 
                width == 0 
                || 
                height == 0
                )
                throw new PlateauSizeException("Please type two numbers (except 0) with one space character between them.");

            Width = width;
            Height = height;
        }
    }
}
