using System.Collections.Generic;

namespace HepsiCase.Application.Contracts
{
    public interface IPlateau
    {
        IList<IRover> Rovers { get; set; }
        int Width { get; set; }
        int Height { get; set; }

        void SetSize(string size);

        void AddRover(IRover rover);
    }
}
