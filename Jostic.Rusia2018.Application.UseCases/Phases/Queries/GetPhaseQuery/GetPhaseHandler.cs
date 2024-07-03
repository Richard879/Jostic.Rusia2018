using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Phases.Queries.GetPhaseQuery
{
    public class GetPhaseHandler : IRequestHandler<GetPhaseQuery, Response<PhaseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPhaseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<PhaseDto>> Handle(GetPhaseQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<PhaseDto>();
            var entity = await _unitOfWork.Phases.GetAsync(request.idFase);
            response.Data = _mapper.Map<PhaseDto>(entity);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
            }
            return response;
        }
    }
}