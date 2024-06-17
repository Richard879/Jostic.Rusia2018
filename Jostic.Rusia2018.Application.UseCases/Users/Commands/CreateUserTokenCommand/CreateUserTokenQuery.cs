using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Users.Commands.CreateUserTokenCommand
{
    public sealed record CreateUserTokenQuery : IRequest<Response<UserDto>>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}