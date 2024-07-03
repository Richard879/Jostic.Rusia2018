using Jostic.Rusia2018.Domain.Entity;

namespace Jostic.Rusia2018.Application.Interface.Persistence
{
    public interface ICountryRepository : IReadable<Country>, IWriteable<Country>, IRemovable<Country>
    {
        Task<IEnumerable<Country>> GetPaisesAllAsync();
        Task<IEnumerable<Country>> GetPaisesAllFiltro(Country entity);
    }
}