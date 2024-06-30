using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Technicals.Commands.UpdateTechnicalCommand
{
    public sealed record UpdateTechnicalCommand : IRequest<Response<bool>>
    {
        public int idTecnico { get; set; }
        public string nomTecnico { get; set; } = string.Empty;
        public string nacionalidad { get; set; } = string.Empty;
        public DateTime? fechaNacimiento { get; set; } = null;
    }
}