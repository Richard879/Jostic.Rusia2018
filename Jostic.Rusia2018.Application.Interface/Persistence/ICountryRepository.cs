using Jostic.Rusia2018.Domain.Entity;

namespace Jostic.Rusia2018.Application.Interface.Persistence
{
    public interface ICountryRepository : IReadable<Country>, IWriteable<Country>, IRemovable<Country>
    {
        Task<IEnumerable<Country>> GetCountriesAllAsync();
        Task<IEnumerable<Country>> GetCountriesAllFilter(Country entity);
        Task<IEnumerable<Country>> GetCountryValidate(Country entity);
    }
}