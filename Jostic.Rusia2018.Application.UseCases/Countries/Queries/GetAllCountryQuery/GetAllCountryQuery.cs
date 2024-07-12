using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Countrys.Queries.GetAllQuery
{
    public sealed record GetAllCountryQuery : IRequest<Response<IEnumerable<CountryDto>>>
    {
    }
}