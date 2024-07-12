using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Countries.Queries.GetCountriesAllQuery
{
    public sealed record GetCountriesAllQuery : IRequest<Response<IEnumerable<CountryDto>>>
    {
    }
}