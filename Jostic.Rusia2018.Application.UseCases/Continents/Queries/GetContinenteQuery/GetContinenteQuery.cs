using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Continentes.Queries.GetContinenteQuery
{
    public sealed record GetContinenteQuery : IRequest<Response<ContinentDto>>
    {
        public int idContinente { get; set; }
    }
}
