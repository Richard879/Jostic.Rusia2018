namespace Jostic.Rusia2018.Application.Interface.Persistence
{
    public interface IUnitOfWork
    {
        IUsersRepository Users { get; }
        IGroupRepository Groups { get; }
        ICountryRepository Countrys { get; }
        IContinentRepository Continents { get; }
        ITechnicalRepository Technicals { get; }
    }
}
