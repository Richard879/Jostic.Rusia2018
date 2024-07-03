using AutoMapper;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Phases.Commands.UpdatePhaseCommand
{
    public class UpdatePhaseHandler : IRequestHandler<UpdatePhaseCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePhaseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(UpdatePhaseCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            var entity = _mapper.Map<Phase>(request);
            response.Data = await _unitOfWork.Phases.UpdateAsync(entity);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Actualización exitosa..!!";
            }
            return response;
        }
    }
}