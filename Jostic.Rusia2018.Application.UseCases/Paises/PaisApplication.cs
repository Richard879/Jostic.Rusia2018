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

        public Response<bool> Delete(int idPais)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> DeleteAsync(int idPais)
        {
            throw new NotImplementedException();
        }

        public Response<PaisDto> Get(int idPais)
        {
            throw new NotImplementedException();
        }

        public Response<IEnumerable<PaisDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Response<List<PaisDto>> GetPaises()
        {
            var response = new Response<List<PaisDto>>();
            try
            {
                var pais = _unitOfWork.Pais.GetPaises().Select(p => new PaisDto
                {
                    idPais = p.idPais,
                    nomPais = p.nomPais,
                    idGrupo = p.grupo.idGrupo,
                    descripcion = p.grupo.descripcion
                }).ToList();

                response.Data = _mapper.Map<List<PaisDto>>(pais);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa..!!";
                    _logger.LogInformation("Consulta exitosa..!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public Task<Response<IEnumerable<PaisDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ResponsePagination<IEnumerable<PaisDto>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ResponsePagination<IEnumerable<PaisDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Response<PaisDto>> GetAsync(int idPais)
        {
            throw new NotImplementedException();
        }

        public Response<bool> Insert(PaisDto paisDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> InsertAsync(PaisDto paisDto)
        {
            throw new NotImplementedException();
        }

        public Response<bool> Update(PaisDto paisDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> UpdateAsync(PaisDto paisDto)
        {
            throw new NotImplementedException();
        }
    }
}
