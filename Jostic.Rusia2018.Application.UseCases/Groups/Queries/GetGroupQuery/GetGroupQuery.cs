using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Groups.Queries.GetGrupoQuery
{
    public sealed record GetGroupQuery : IRequest<Response<GroupDto>>
    {
        public int idGrupo { get; set; }
    }
}