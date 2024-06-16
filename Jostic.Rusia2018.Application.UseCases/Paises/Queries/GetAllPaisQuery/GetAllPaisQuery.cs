using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Paises.Queries.GetAllQuery
{
    public sealed record GetAllPaisQuery : IRequest<Response<IEnumerable<PaisDto>>>
    {
    }
}
