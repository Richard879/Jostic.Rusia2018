using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Application.Interface.UseCases;
using Jostic.Rusia2018.Transversal.Common;
using Microsoft.Extensions.Caching.Distributed;

namespace Jostic.Rusia2018.Application.UseCases.Paises
{
    public class PaisApplication : IPaisApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PaisApplication> _logger;
        private readonly IDistributedCache _distributedCache;

        public PaisApplication(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<PaisApplication> logger, IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _distributedCache = distributedCache;
        }
        #region Métodos Síncronos

        public Response<bool> Insert(CountryDto paisDto)
        {
            throw new NotImplementedException();
        }

        public Response<bool> Update(CountryDto paisDto)
        {
            throw new NotImplementedException();
        }

        public Response<bool> Delete(int idPais)
        {
            throw new NotImplementedException();
        }

        public Response<CountryDto> Get(int idPais)
        {
            throw new NotImplementedException();
        }

        public Response<IEnumerable<CountryDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Response<IEnumerable<CountryDto>> GetPaisesAll()
        {
            var response = new Response<IEnumerable<CountryDto>>();
            var paisDto = _unitOfWork.Countrys.GetPaisesAll();

            response.Data = _mapper.Map<IEnumerable<CountryDto>>(paisDto);

            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
                _logger.LogInformation("Consulta exitosa..!!");
            }
            return response;
        }

        public ResponsePagination<IEnumerable<CountryDto>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Métodos Asíncronos

        public Task<Response<bool>> InsertAsync(CountryDto paisDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> UpdateAsync(CountryDto paisDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteAsync(int idPais)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CountryDto>> GetAsync(int idPais)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<CountryDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IEnumerable<CountryDto>>> GetPaisesAllAsync()
        {
            var response = new Response<IEnumerable<CountryDto>>();
            var paisDto = await _unitOfWork.Countrys.GetPaisesAllAsync();
            /*var paises = pais.Select(p => new PaisDto
            {
                idPais = p.idPais,
                nomPais = p.nomPais,
                idGrupo = p.grupo.idGrupo,
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
                _logger.LogInformation("Consulta exitosa..!!");
            }
            return response;
        }

        public Task<ResponsePagination<IEnumerable<CountryDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}