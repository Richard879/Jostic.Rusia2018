using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Technicals.Queries.GetAllWithPaginationTechnicalQuery
{
    public sealed record GetAllWithPaginationTechnicalQuery : IRequest<ResponsePagination<IEnumerable<TechnicalDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}