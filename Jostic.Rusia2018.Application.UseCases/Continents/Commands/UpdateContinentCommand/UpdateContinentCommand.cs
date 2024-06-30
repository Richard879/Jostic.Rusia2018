using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Continents.Commands.UpdateContinentCommand
{
    public sealed record UpdateContinentCommand : IRequest<Response<bool>>
    {
        public int idContinente { get; set; }
        public string descripcion { get; set; } = string.Empty;
    }
}