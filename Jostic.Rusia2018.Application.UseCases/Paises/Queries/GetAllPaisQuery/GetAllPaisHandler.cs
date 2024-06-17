using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Jostic.Rusia2018.Application.UseCases.Paises.Queries.GetAllQuery
{
    public class GetAllPaisHandler : IRequestHandler<GetAllPaisQuery, Response<IEnumerable<PaisDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PaisApplication> _logger;
        private readonly IDistributedCache _distributedCache;

        public GetAllPaisHandler(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<PaisApplication> logger, IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _distributedCache = distributedCache;
        }

        public async Task<Response<IEnumerable<PaisDto>>> Handle(GetAllPaisQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<PaisDto>>();
            try
            {
                var pais = await _unitOfWork.Pais.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<PaisDto>>(pais);

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