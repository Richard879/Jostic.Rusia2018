using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Groups.Commands.UpdateGrupoCommand
{
    public sealed record UpdateGroupCommand : IRequest<Response<bool>>
    {
        public int idGrupo { get; set; }
        public string descripcion { get; set; } = string.Empty;
    }
}