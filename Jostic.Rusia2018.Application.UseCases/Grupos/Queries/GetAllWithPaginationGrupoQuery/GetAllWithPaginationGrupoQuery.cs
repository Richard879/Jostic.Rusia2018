using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Grupos.Queries.GetAllWithPaginationGrupoQuery
{
    public sealed record GetAllWithPaginationGrupoQuery : IRequest<ResponsePagination<IEnumerable<GrupoDto>>>
    {
        public int PageNumber {  get; set; }
        public int PageSize { get; set; } 
    }
}
