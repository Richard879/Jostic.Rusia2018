using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Continents.Queries.GetAllWithPaginationContinentQuery
{
    public sealed record GetAllWithPaginationContinentQuery : IRequest<ResponsePagination<IEnumerable<ContinentDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}