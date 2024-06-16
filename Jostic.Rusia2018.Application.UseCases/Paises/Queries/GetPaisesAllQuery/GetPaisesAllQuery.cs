using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Paises.Queries.GetPaisesAllQuery
{
    public sealed record GetPaisesAllQuery : IRequest<Response<IEnumerable<PaisDto>>>
    {
    }
}
