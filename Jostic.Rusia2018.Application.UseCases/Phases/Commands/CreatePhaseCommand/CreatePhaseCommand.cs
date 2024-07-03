using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Phases.Commands.CreatePhaseCommand
{
    public sealed record CreatePhaseCommand : IRequest<Response<bool>>
    {
        public string descripcion { get; set; } = string.Empty;
    }
}