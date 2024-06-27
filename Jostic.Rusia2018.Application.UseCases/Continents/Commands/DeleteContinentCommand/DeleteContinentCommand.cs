using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Continents.Commands.DeleteContinentCommand
{
    public sealed record DeleteContinentCommand : IRequest<Response<bool>>
    {
        public int idContinente { get; set; }
    }
}