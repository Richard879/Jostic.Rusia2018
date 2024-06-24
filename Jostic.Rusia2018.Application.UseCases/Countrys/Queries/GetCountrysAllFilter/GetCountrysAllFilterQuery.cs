using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Countrys.Queries.GetPaisesAllFilter
{
    public sealed record GetCountryAllFilterQuery : IRequest<Response<IEnumerable<CountryDto>>>
    {
        public int idPais { get; set; }
        public string nomPais { get; set; } = string.Empty;

        public GroupDto grupo = new GroupDto();
        public ContinentDto continente = new ContinentDto();
        public TechnicalDto tecnico = new TechnicalDto();
    }
}