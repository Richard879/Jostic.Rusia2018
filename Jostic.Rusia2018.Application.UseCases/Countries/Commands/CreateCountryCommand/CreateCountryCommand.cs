using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Countrys.Commands.CreateCountryCommand
{
    public sealed record CreateCountryCommand : IRequest<Response<bool>>
    {
        public string nomPais { get; set; } = string.Empty;

        public required GroupDto grupo { get; set; } = null!;
        public required ContinentDto continente { get; set; } = null!;
        public required TechnicalDto tecnico { get; set; } = null!;
    }
}