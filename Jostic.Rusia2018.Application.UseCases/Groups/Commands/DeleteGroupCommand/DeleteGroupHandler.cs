using AutoMapper;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Jostic.Rusia2018.Application.UseCases.Groups.Commands.DeleteGrupoCommand
{
    public class DeleteGroupHandler : IRequestHandler<DeleteGroupCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _distributedCache;

        public DeleteGroupHandler(IUnitOfWork unitOfWork, IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _distributedCache = distributedCache;
        }

        public async Task<Response<bool>> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            response.Data = await _unitOfWork.Groups.DeleteAsync(request.idGrupo);
            if (response.Data)
            {
                await _distributedCache.RemoveAsync("grupoList");
                response.IsSuccess = true;
                response.Message = "Eliminación exitosa..!!";
            }
            return response;
        }
    }
}
