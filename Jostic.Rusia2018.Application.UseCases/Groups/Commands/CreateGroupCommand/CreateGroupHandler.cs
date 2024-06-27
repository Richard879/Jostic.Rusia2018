using AutoMapper;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Jostic.Rusia2018.Application.UseCases.Groups.Commands.CreateGrupoCommand
{
    public class CreateGroupHandler : IRequestHandler<CreateGroupCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public CreateGroupHandler(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<Response<bool>> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            var entity = _mapper.Map<Group>(request);
            response.Data = await _unitOfWork.Groups.InsertAsync(entity);
            if (response.Data)
            {
                await _distributedCache.RemoveAsync("grupoList");
                response.IsSuccess = true;
                response.Message = "Registro exitoso..!!";
            }
            return response;
        }
    }
}