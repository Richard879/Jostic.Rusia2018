using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Phases.Queries.GetAllPhaseQuery
{
    public sealed record GetAllPhaseQuery : IRequest<Response<IEnumerable<PhaseDto>>>
    {
    }
}