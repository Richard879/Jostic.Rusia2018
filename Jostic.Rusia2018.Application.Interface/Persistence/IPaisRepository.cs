using Jostic.Rusia2018.Domain.Entity;

namespace Jostic.Rusia2018.Application.Interface.Persistence
{
    public interface IPaisRepository: IGenericRepository<Pais> 
    {
        IEnumerable<Pais> GetPaisesAll();
        Task<IEnumerable<Pais>> GetPaisesAllAsync();
    }
}
