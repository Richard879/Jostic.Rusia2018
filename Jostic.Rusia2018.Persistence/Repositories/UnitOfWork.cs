using Jostic.Rusia2018.Application.Interface.Persistence;

namespace Jostic.Rusia2018.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUsersRepository Users { get; }

        public IGrupoRepository Groups { get; }

        public IPaisRepository Countrys { get; }

        public IContinentRepository Continents { get; }

        public UnitOfWork(IUsersRepository user, IGrupoRepository group, IPaisRepository pais, IContinentRepository continents)
        {
            Users = user;
            Groups = group;
            Countrys = pais;
            Continents = continents;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
