using Jostic.Rusia2018.Domain.Entity;

namespace Jostic.Rusia2018.Application.Interface.Persistence
{
    public interface IContinentRepository : IReadable<Continent>, IWriteable<Continent>, IRemovable<Continent>
    {
    }
}