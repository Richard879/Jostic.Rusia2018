using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Continents.Queries.GetAllWithPaginationContinentQuery
{
    public class GetAllWithPaginationContinentHandler : IRequestHandler<GetAllWithPaginationContinentQuery, ResponsePagination<IEnumerable<ContinentDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllWithPaginationContinentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponsePagination<IEnumerable<ContinentDto>>> Handle(GetAllWithPaginationContinentQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponsePagination<IEnumerable<ContinentDto>>();
            var count = await _unitOfWork.Continents.CountAsync();
            var entity = await _unitOfWork.Continents.GetAllWithPaginationAsync(request.PageNumber, request.PageSize);
            response.Data = _mapper.Map<IEnumerable<ContinentDto>>(entity);
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