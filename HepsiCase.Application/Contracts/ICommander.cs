namespace HepsiCase.Application.Contracts
{
    public interface ICommander
    {
        IPlateau Plateau { get; set; }

        void Move(IRover rover);
    }
}
