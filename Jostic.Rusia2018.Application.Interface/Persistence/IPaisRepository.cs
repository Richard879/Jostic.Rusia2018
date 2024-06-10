using Jostic.Rusia2018.Domain.Entity;

namespace Jostic.Rusia2018.Application.Interface.Persistence
{
    public interface IPaisRepository: IGenericRepository<Pais> 
    {
        List<Pais> GetPaises();
        Task<List<Pais>> GetPaisesAsync();
    }
}
