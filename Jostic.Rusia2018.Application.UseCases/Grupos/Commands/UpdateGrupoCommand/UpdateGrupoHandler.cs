using AutoMapper;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Jostic.Rusia2018.Application.UseCases.Grupos.Commands.UpdateGrupoCommand
{
    public class UpdateGrupoHandler : IRequestHandler<UpdateGrupoCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public UpdateGrupoHandler(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<Response<bool>> Handle(UpdateGrupoCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            var grupo = _mapper.Map<Grupo>(request);
            response.Data = await _unitOfWork.Grupo.UpdateAsync(grupo);
            if (response.Data)
            {
                await _distributedCache.RemoveAsync("grupoList");
                response.IsSuccess = true;
                response.Message = "Actualización exitosa..!!";
            }
            return response;
        }
    }
}
