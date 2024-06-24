using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.UseCases;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Groups.Queries.GetAllGrupoQuery
{
    public sealed record GetAllGroupQuery : IRequest<Response<IEnumerable<GroupDto>>>, ICacheable
    {
        //public bool BypassCache => false;

        public string CacheKey => "grupoList";

        public int SlidingExpirationInMinutes => 30;

        public int AbsoluteExpirationInMinutes => 60;
    }
}
