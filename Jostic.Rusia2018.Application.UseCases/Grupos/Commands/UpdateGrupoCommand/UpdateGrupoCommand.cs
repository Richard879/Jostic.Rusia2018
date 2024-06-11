using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Grupos.Commands.UpdateGrupoCommand
{
    public sealed record UpdateGrupoCommand : IRequest<Response<bool>>
    {
        public int idGrupo { get; set; }
        public string descripcion { get; set; } = string.Empty;
    }
}
