using AutoMapper;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Continents.Commands.UpdateContinentCommand
{
    public class UpdateContinentHandler : IRequestHandler<UpdateContinentCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateContinentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(UpdateContinentCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            var entity = _mapper.Map<Continent>(request);
            response.Data = await _unitOfWork.Continents.UpdateAsync(entity);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Actualización exitosa..!!";
            }
            return response;
        }
    }
}