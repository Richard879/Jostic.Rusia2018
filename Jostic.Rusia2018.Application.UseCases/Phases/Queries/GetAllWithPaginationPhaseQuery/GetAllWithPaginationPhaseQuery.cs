using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Phases.Queries.GetAllWithPaginationPhaseQuery
{
    public sealed record GetAllWithPaginationPhaseQuery : IRequest<ResponsePagination<IEnumerable<PhaseDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}