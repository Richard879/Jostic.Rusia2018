using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Continents.Queries.GetAllGrupoQuery
{
    public class GetAllContinentHandler : IRequestHandler<GetAllContinentQuery, Response<IEnumerable<ContinentDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllContinentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ContinentDto>>> Handle(GetAllContinentQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<ContinentDto>>();

            var entity = await _unitOfWork.Continents.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<ContinentDto>>(entity);

            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
                //_logger.LogInformation("Consulta exitosa..!!");
            }
            return response;
        }
    }
}
