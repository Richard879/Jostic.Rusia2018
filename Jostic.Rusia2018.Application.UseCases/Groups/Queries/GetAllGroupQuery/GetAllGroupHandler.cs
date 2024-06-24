using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Groups.Queries.GetAllGrupoQuery
{
    public class GetAllGroupHandler : IRequestHandler<GetAllGroupQuery, Response<IEnumerable<GroupDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IAppLogger<GrupoApplication> _logger;
        //private readonly IDistributedCache _distributedCache;

        public GetAllGroupHandler(IUnitOfWork unitOfWork, IMapper mapper/*, IAppLogger<GrupoApplication> logger ,  IDistributedCache distributedCache*/)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_logger = logger;
            //_distributedCache = distributedCache;
        }

        public async Task<Response<IEnumerable<GroupDto>>> Handle(GetAllGroupQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<GroupDto>>();

            var grupos = await _unitOfWork.Groups.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<GroupDto>>(grupos);

            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
                //_logger.LogInformation("Consulta exitosa..!!");
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
