using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Continentes.Queries.GetContinenteQuery
{
    public class GetContinenteHandler : IRequestHandler<GetContinenteQuery, Response<ContinentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetContinenteHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<ContinentDto>> Handle(GetContinenteQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<ContinentDto>();
            var entity = await _unitOfWork.Continents.GetAsync(request.idContinente);
            response.Data = _mapper.Map<ContinentDto>(entity);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
            }
            return response;
        }
    }
}