using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Grupos.Queries.GetAllGrupoQuery
{
    public sealed record GetAllGrupoQuery : IRequest<Response<IEnumerable<GrupoDto>>>
    {

    }
}
