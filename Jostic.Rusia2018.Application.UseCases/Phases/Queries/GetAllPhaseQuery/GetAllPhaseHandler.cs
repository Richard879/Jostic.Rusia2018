using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Phases.Queries.GetAllPhaseQuery
{
    public class GetAllPhaseHandler : IRequestHandler<GetAllPhaseQuery, Response<IEnumerable<PhaseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPhaseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<PhaseDto>>> Handle(GetAllPhaseQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<PhaseDto>>();

            var entity = await _unitOfWork.Phases.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<PhaseDto>>(entity);

            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
            }
            return response;
        }
    }
}