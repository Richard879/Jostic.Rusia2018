using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Phases.Commands.UpdatePhaseCommand
{
    public sealed record UpdatePhaseCommand : IRequest<Response<bool>>
    {
        public int idFase { get; set; }
        public string descripcion { get; set; } = string.Empty;
    }
}