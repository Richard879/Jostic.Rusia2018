namespace Jostic.Rusia2018.Application.Interface.Persistence
{
    public interface IUnitOfWork
    {
        IUsersRepository Users { get; }
        IGrupoRepository Grupo { get; }
        IPaisRepository Pais { get; }
    }
}
