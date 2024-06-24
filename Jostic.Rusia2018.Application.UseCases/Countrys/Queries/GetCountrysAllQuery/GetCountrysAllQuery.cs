using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Countrys.Queries.GetPaisesAllQuery
{
    public sealed record GetCountrysAllQuery : IRequest<Response<IEnumerable<CountryDto>>>
    {
    }
}