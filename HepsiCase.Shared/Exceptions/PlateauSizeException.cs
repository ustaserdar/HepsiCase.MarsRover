using HepsiCase.Shared.Enums;
using System;

namespace HepsiCase.Shared.Exceptions
{
    public class PlateauSizeException : Exception
    {

        public PlateauSizeException() : base("Plateau size exceeded.")
        {

        }

        public PlateauSizeException(Directions direction) : base($"Reached plateau {direction} direction boundary. Cannot move forward to this direction!")
        {

        }

        public PlateauSizeException(string message) : base(message)
        {

        }
    }
}
