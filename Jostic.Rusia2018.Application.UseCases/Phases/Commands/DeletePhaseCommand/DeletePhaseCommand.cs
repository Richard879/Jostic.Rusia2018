using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Phases.Commands.DeletePhaseCommand
{
    public sealed record DeletePhaseCommand : IRequest<Response<bool>>
    {
        public int idFase { get; set; }
    }
}