using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Grupos.Commands.DeleteGrupoCommand
{
    public sealed record DeleteGrupoCommand : IRequest<Response<bool>>
    {
        public int idGrupo { get; set; }
    }
}
