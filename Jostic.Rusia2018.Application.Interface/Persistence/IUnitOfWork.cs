namespace Jostic.Rusia2018.Application.Interface.Persistence
{
    public interface IUnitOfWork
    {
        IUsersRepository Users { get; }
        IGrupoRepository Groups { get; }
        IPaisRepository Countrys { get; }
        IContinentRepository Continents { get; }
    }
}
