using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Groups.Queries.GetAllWithPaginationGrupoQuery
{
    public class GetAllWithPaginationGroupHandler : IRequestHandler<GetAllWithPaginationGroupQuery, ResponsePagination<IEnumerable<GroupDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllWithPaginationGroupHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponsePagination<IEnumerable<GroupDto>>> Handle(GetAllWithPaginationGroupQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponsePagination<IEnumerable<GroupDto>>();
            var count = await _unitOfWork.Groups.CountAsync();
            var customers = await _unitOfWork.Groups.GetAllWithPaginationAsync(request.PageNumber, request.PageSize);
            response.Data = _mapper.Map<IEnumerable<GroupDto>>(customers);
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
