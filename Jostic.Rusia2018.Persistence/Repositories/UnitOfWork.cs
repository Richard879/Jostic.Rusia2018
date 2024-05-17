using Jostic.Rusia2018.Application.Interface.Persistence;

namespace Jostic.Rusia2018.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUsersRepository Users { get; }

        public IGrupoRepository Grupo { get; }

        public UnitOfWork(IUsersRepository users, IGrupoRepository grupo)
        {
            Users = users;
            Grupo = grupo;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
