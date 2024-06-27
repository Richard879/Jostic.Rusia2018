using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Continents.Commands.CreateContinentCommand
{
    public sealed record CreateContinentCommand : IRequest<Response<bool>>
    {
        public string descripcion { get; set; } = string.Empty;
    }
}