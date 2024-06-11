using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Jostic.Rusia2018.Application.UseCases.Grupos.Queries.GetAllWithPaginationGrupoQuery
{
    public class GetAllWithPaginationGrupoHandler : IRequestHandler<GetAllWithPaginationGrupoQuery, ResponsePagination<IEnumerable<GrupoDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GrupoApplication> _logger;
        private readonly IDistributedCache _distributedCache;

        public GetAllWithPaginationGrupoHandler(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<GrupoApplication> logger, IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _distributedCache = distributedCache;
        }

        public async Task<ResponsePagination<IEnumerable<GrupoDto>>> Handle(GetAllWithPaginationGrupoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponsePagination<IEnumerable<GrupoDto>>();
            try
            {
                var count = await _unitOfWork.Grupo.CountAsync();
                var customers = await _unitOfWork.Grupo.GetAllWithPaginationAsync(request.PageNumber, request.PageSize);
                response.Data = _mapper.Map<IEnumerable<GrupoDto>>(customers);
                if (response.Data != null)
                {
                    response.PageNumer = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    response.IsSuccess = true;
                    response.Message = "Consulta paginada exitosa..!!";
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
