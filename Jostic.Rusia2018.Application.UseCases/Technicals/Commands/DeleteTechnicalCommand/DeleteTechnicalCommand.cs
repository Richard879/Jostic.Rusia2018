using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Technicals.Commands.DeleteTechnicalCommand
{
    public sealed record DeleteTechnicalCommand : IRequest<Response<bool>>
    {
        public int idTecnico { get; set; }
    }
}
