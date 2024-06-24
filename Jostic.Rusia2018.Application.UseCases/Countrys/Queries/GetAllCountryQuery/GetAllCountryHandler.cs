using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Countrys.Queries.GetAllQuery
{
    public class GetAllCountryHandler : IRequestHandler<GetAllCountryQuery, Response<IEnumerable<CountryDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCountryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<CountryDto>>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<CountryDto>>();
            var pais = await _unitOfWork.Countrys.GetAllAsync();

            response.Data = _mapper.Map<IEnumerable<CountryDto>>(pais);

            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
            }
            return response;
        }
    }
}