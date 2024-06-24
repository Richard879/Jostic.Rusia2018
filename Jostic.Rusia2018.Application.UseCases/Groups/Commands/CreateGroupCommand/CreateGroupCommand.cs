using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Groups.Commands.CreateGrupoCommand
{
    public sealed record CreateGroupCommand : IRequest<Response<bool>>
    {
        public string descripcion { get; set; } = string.Empty;
    }
}