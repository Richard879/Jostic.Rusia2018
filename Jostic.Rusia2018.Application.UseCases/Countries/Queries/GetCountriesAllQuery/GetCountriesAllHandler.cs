using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Countries.Queries.GetCountriesAllQuery
{
    public class GetCountriesAllHandler : IRequestHandler<GetCountriesAllQuery, Response<IEnumerable<CountryDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCountriesAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<CountryDto>>> Handle(GetCountriesAllQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<CountryDto>>();

            var paisDto = await _unitOfWork.Countries.GetCountriesAllAsync();
                /*var paises = paisDto.Select(p => new PaisDto
                {
                    idPais = p.idPais,
                    nomPais = p.nomPais,
                    grupo.id = p.grupo.idGrupo,
                    descripcion = p.grupo.descripcion,
                    idContinente = p.continente.idContinente,
                    nomContinente = p.continente.descripcion,
                    idTecnico = p.tecnico.idTecnico,
                    nomTecnico = p.tecnico.nomTecnico
                }).ToList();*/

            response.Data = _mapper.Map<IEnumerable<CountryDto>>(paisDto);

            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
            }
            return response;
        }
    }
}