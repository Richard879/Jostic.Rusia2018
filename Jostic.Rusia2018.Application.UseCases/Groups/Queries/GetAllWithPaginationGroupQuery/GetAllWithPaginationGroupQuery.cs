using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Groups.Queries.GetAllWithPaginationGrupoQuery
{
    public sealed record GetAllWithPaginationGroupQuery : IRequest<ResponsePagination<IEnumerable<GroupDto>>>
    {
        public int PageNumber {  get; set; }
        public int PageSize { get; set; } 
    }
}
