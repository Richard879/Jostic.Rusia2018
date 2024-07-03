using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Phases.Queries.GetAllWithPaginationPhaseQuery
{
    public class GetAllWithPaginationPhaseHandler : IRequestHandler<GetAllWithPaginationPhaseQuery, ResponsePagination<IEnumerable<PhaseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllWithPaginationPhaseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponsePagination<IEnumerable<PhaseDto>>> Handle(GetAllWithPaginationPhaseQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponsePagination<IEnumerable<PhaseDto>>();
            var count = await _unitOfWork.Phases.CountAsync();
            var entity = await _unitOfWork.Phases.GetAllWithPaginationAsync(request.PageNumber, request.PageSize);
            response.Data = _mapper.Map<IEnumerable<PhaseDto>>(entity);
            if (response.Data != null)
            {
                response.PageNumer = request.PageNumber;
                response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                response.TotalCount = count;
                response.IsSuccess = true;
                response.Message = "Consulta paginada exitosa..!!";
            }
            return response;
        }
    }
}