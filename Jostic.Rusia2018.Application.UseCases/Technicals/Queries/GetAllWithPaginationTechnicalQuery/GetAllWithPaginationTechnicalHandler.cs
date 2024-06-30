using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Technicals.Queries.GetAllWithPaginationTechnicalQuery
{
    public class GetAllWithPaginationTechnicalHandler : IRequestHandler<GetAllWithPaginationTechnicalQuery, ResponsePagination<IEnumerable<TechnicalDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllWithPaginationTechnicalHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponsePagination<IEnumerable<TechnicalDto>>> Handle(GetAllWithPaginationTechnicalQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponsePagination<IEnumerable<TechnicalDto>>();
            var count = await _unitOfWork.Technicals.CountAsync();
            var entity = await _unitOfWork.Technicals.GetAllWithPaginationAsync(request.PageNumber, request.PageSize);
            response.Data = _mapper.Map<IEnumerable<TechnicalDto>>(entity);
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