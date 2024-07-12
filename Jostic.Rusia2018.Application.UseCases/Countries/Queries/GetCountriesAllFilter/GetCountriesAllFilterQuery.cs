using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Countries.Queries.GetCountriesAllFilter
{
    public sealed record GetCountryAllFilterQuery : IRequest<Response<IEnumerable<CountryDto>>>
    {
        public int idPais { get; set; }
        public string nomPais { get; set; } = string.Empty;

        public required GroupDto grupo { get; set; } = null!;
        public required ContinentDto continente { get; set; } = null!;
        public required TechnicalDto tecnico { get; set; } = null!;
    }
}