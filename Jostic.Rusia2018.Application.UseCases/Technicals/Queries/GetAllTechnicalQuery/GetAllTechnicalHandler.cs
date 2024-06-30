using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Technicals.Queries.GetAllTechnicalQuery
{
    public class GetAllTechnicalHandler : IRequestHandler<GetAllTechnicalQuery, Response<IEnumerable<TechnicalDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTechnicalHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<TechnicalDto>>> Handle(GetAllTechnicalQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<TechnicalDto>>();

            var entity = await _unitOfWork.Technicals.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<TechnicalDto>>(entity);

            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
            }
            return response;
        }
    }
}