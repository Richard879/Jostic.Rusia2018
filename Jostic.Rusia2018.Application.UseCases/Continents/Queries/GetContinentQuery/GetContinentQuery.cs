using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Continentes.Queries.GetContinentQuery
{
    public sealed record GetContinentQuery : IRequest<Response<ContinentDto>>
    {
        public int idContinente { get; set; }
    }
}
