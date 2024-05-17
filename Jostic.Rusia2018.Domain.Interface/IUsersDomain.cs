using Usat.Ecommerce.Domain.Entity;

namespace Usat.Ecommerce.Domain.Interface
{
    public interface IUsersDomain
    {
        User Authenticate(string username, string password);
    }
}
