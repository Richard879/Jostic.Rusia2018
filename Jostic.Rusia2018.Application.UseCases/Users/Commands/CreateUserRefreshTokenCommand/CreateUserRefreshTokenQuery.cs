using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jostic.Rusia2018.Application.UseCases.Users.Commands.CreateUserRefreshTokenCommand
{
    public sealed record CreateUserRefreshTokenQuery : IRequest<Response<UserDto>>
    {
        public int UserId { get; set; }
    }
}