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
        public IPhaseRepository Phases { get; }

        public UnitOfWork(IUsersRepository user, IGroupRepository group, ICountryRepository country, IContinentRepository continents, ITechnicalRepository technicals, IPhaseRepository phases)
        {
            Users = user;
            Groups = group;
            Countrys = country;
            Continents = continents;
            Technicals = technicals;
            Phases = phases;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}