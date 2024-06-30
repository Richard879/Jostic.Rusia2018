using Jostic.Rusia2018.Application.Interface.Persistence;

namespace Jostic.Rusia2018.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUsersRepository Users { get; }

        public IGroupRepository Groups { get; }

        public ICountryRepository Countrys { get; }

        public IContinentRepository Continents { get; }

        public ITechnicalRepository Technicals { get; }

        public UnitOfWork(IUsersRepository user, IGroupRepository group, ICountryRepository pais, IContinentRepository continents, ITechnicalRepository technicals)
        {
            Users = user;
            Groups = group;
            Countrys = pais;
            Continents = continents;
            Technicals = technicals;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
