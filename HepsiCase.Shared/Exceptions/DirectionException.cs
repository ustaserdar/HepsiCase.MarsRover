using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiCase.Shared.Exceptions
{
    public class DirectionException : Exception
    {
        public DirectionException() : base("Invalid direction. Direction should be one of N, E, S or W.")
        {

        }
    }
}
