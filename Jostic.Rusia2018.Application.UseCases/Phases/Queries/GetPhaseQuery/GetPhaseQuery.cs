using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Phases.Queries.GetPhaseQuery
{
    public sealed record GetPhaseQuery : IRequest<Response<PhaseDto>>
    {
        public int idFase { get; set; }
    }
}