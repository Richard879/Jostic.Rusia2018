using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Jostic.Rusia2018.Application.UseCases.Grupos.Queries.GetGrupoQuery
{
    public class GetGrupoHandler : IRequestHandler<GetGrupoQuery, Response<GrupoDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public GetGrupoHandler(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<Response<GrupoDto>> Handle(GetGrupoQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<GrupoDto>();
            var grupo = await _unitOfWork.Grupo.GetAsync(request.idGrupo);
            response.Data = _mapper.Map<GrupoDto>(grupo);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
            }
            return response;
        }
    }
}