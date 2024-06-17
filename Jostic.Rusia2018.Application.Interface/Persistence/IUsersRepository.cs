using Jostic.Rusia2018.Domain.Entity;

namespace Jostic.Rusia2018.Application.Interface.Persistence
{
    public interface IUsersRepository
    {
        Task<User> Authenticate(string username, string password);
    }
}