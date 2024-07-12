using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Countries.Queries.GetCountriesAllFilter
{
    public class GetCountriesAllFilterHandler : IRequestHandler<GetCountryAllFilterQuery, Response<IEnumerable<CountryDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCountriesAllFilterHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<CountryDto>>> Handle(GetCountryAllFilterQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<CountryDto>>();
            var entity = _mapper.Map<Country>(request);
            var entityDto = await _unitOfWork.Countries.GetCountriesAllFilter(entity);

            response.Data = _mapper.Map<IEnumerable<CountryDto>>(entityDto);

            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
            }
            return response;
        }
    }
}