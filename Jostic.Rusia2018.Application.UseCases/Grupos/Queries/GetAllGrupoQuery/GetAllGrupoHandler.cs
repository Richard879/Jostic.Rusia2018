using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace Jostic.Rusia2018.Application.UseCases.Grupos.Queries.GetAllGrupoQuery
{
    public class GetAllGrupoHandler : IRequestHandler<GetAllGrupoQuery, Response<IEnumerable<GrupoDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GrupoApplication> _logger;
        private readonly IDistributedCache _distributedCache;

        public GetAllGrupoHandler(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<GrupoApplication> logger,  IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _distributedCache = distributedCache;
        }

        public async Task<Response<IEnumerable<GrupoDto>>> Handle(GetAllGrupoQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GrupoDto>>();

            var grupos = await _unitOfWork.Grupo.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<GrupoDto>>(grupos);

            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
                _logger.LogInformation("Consulta exitosa..!!");
            }
            return response;

            /*var cacheKey = "grupoList";
            //TimeSpan? slidingExpiration = null;

            var redisGrupo = await _distributedCache.GetAsync(cacheKey);
            if (redisGrupo != null)
            {
                response.Data = JsonSerializer.Deserialize<IEnumerable<GrupoDto>>(redisGrupo);
            }
            else
            {
            var grupos = await _unitOfWork.Grupo.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<GrupoDto>>(grupos);
                if (response.Data != null)
                {
                    var serializerGrupo = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response.Data));
                    var cacheEntryOptions = new DistributedCacheEntryOptions
                    {
                        SlidingExpiration = slidingExpiration ?? TimeSpan.FromMinutes(30)
                    };
                    var options = new DistributedCacheEntryExtensions()
                        .SetAbsoluteExpiration(DateTime.Now.AddSeconds(10))
                    .SetSlidingExpiration(DateTime.Now.AddSeconds(5));

                    await _distributedCache.SetAsync(cacheKey, serializerGrupo, cacheEntryOptions);
                }
            }*/
        }
    }
}
