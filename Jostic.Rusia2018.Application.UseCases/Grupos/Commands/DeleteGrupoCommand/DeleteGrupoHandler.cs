using AutoMapper;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Jostic.Rusia2018.Application.UseCases.Grupos.Commands.DeleteGrupoCommand
{
    public class DeleteGrupoHandler : IRequestHandler<DeleteGrupoCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _distributedCache;

        public DeleteGrupoHandler(IUnitOfWork unitOfWork, IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _distributedCache = distributedCache;
        }

        public async Task<Response<bool>> Handle(DeleteGrupoCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _unitOfWork.Grupo.DeleteAsync(request.idGrupo);
                if (response.Data)
                {
                    await _distributedCache.RemoveAsync("grupoList");
                    response.IsSuccess = true;
                    response.Message = "Eliminación exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
