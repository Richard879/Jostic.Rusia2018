using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Technicals.Queries.GetTechnicalQuery
{
    public class GetTechnicalHandler : IRequestHandler<GetTechnicalQuery, Response<TechnicalDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTechnicalHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<TechnicalDto>> Handle(GetTechnicalQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<TechnicalDto>();
            var entity = await _unitOfWork.Technicals.GetAsync(request.idTecnico);
            response.Data = _mapper.Map<TechnicalDto>(entity);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
            }
            return response;
        }
    }
}