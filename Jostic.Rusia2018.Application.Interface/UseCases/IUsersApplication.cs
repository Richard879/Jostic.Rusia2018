using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;

namespace Jostic.Rusia2018.Application.Interface.UseCases
{
    public interface IUsersApplication
    {
        Response<UserDto> Authenticate(string username, string password);
    }
}
