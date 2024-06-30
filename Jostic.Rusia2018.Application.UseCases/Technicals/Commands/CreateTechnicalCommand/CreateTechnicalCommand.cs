using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Technicals.Commands.CreateTechnicalCommand
{
    public sealed record CreateTechnicalCommand : IRequest<Response<bool>>
    {
        public string nomTecnico { get; set; } = string.Empty;
        public string nacionalidad { get; set; } = string.Empty;
        public DateTime? fechaNacimiento { get; set; } = null;
    }
}