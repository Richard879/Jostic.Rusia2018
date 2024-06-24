using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.UseCases;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Continents.Queries.GetAllGrupoQuery
{
    public sealed record GetAllContinentQuery : IRequest<Response<IEnumerable<ContinentDto>>>, ICacheable
    {
        public string CacheKey => "continenteList";

        public int SlidingExpirationInMinutes => 30;

        public int AbsoluteExpirationInMinutes => 60;
    }
}
