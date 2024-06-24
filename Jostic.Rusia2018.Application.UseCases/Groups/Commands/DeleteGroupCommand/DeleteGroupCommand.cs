using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Groups.Commands.DeleteGrupoCommand
{
    public sealed record DeleteGroupCommand : IRequest<Response<bool>>
    {
        public int idGrupo { get; set; }
    }
}
