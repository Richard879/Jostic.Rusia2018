using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Paises.Queries.GetPaisesAllFilter
{
    public sealed record GetPaisesAllFilterQuery : IRequest<Response<IEnumerable<PaisDto>>>
    {
        public int idPais { get; set; }
        public string nomPais { get; set; } = string.Empty;

        public GrupoDto grupo = new GrupoDto();
        public ContinenteDto continente = new ContinenteDto();
        public TecnicoDto tecnico = new TecnicoDto();
    }
}
