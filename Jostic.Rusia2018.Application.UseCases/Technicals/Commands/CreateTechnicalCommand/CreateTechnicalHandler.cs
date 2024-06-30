using AutoMapper;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Technicals.Commands.CreateTechnicalCommand
{
    public class CreateTechnicalHandler : IRequestHandler<CreateTechnicalCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTechnicalHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateTechnicalCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            var entity = _mapper.Map<Technical>(request);
            response.Data = await _unitOfWork.Technicals.InsertAsync(entity);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Registro exitoso..!!";
            }
            return response;
        }
    }
}