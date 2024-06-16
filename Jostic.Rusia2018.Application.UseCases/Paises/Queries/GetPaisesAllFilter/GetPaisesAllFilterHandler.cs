using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Jostic.Rusia2018.Application.UseCases.Paises.Queries.GetPaisesAllFilter
{
    public class GetPaisesAllFilterHandler : IRequestHandler<GetPaisesAllFilterQuery, Response<IEnumerable<PaisDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PaisApplication> _logger;
        private readonly IDistributedCache _distributedCache;

        public GetPaisesAllFilterHandler(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<PaisApplication> logger, IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _distributedCache = distributedCache;
        }

        public async Task<Response<IEnumerable<PaisDto>>> Handle(GetPaisesAllFilterQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<PaisDto>>();
            try
            {
                var pais = _mapper.Map<Pais>(request);
                var paisDto = await _unitOfWork.Pais.GetPaisesAllFiltro(pais);
                var respuesta = paisDto.Select(p => new PaisDto
                {
                    idPais = p.idPais,
                    nomPais = p.nomPais,
                    idGrupo = p.grupo.idGrupo,
                    descripcion = p.grupo.descripcion,
                    idContinente = p.continente.idContinente,
                    nomContinente = p.continente.descripcion,
                    idTecnico = p.tecnico.idTecnico,
                    nomTecnico = p.tecnico.nomTecnico
                }).ToList();

                response.Data = _mapper.Map<IEnumerable<PaisDto>>(respuesta);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa..!!";
                    _logger.LogInformation("Consulta exitosa..!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }
    }
}
