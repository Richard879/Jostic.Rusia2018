using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Grupos.Queries.GetGrupoQuery
{
    public sealed record GetGrupoQuery : IRequest<Response<GrupoDto>>
    {
        public int idGrupo { get; set; }
    }
}
