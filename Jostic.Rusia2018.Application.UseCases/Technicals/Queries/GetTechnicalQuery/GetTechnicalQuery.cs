using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Technicals.Queries.GetTechnicalQuery
{
    public sealed record GetTechnicalQuery : IRequest<Response<TechnicalDto>>
    {
        public int idTecnico{ get; set; }
    }
}