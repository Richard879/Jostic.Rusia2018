using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Application.Interface.UseCases;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Transversal.Common;

namespace Jostic.Rusia2018.Application.UseCases.Grupos
{
    public class GrupoApplication : IGrupoApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GrupoApplication> _logger;

        public GrupoApplication(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<GrupoApplication> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        #region Métodos Síncronos
        public Response<bool> Insert(GrupoDto entity)
        {
            var response = new Response<bool>();
            try
            {
                var grupo = _mapper.Map<Grupo>(entity);
                response.Data = _unitOfWork.Grupo.Insert(grupo);
                if (response.Data)
                {
                    response.IsSucces = true;
                    response.Message = "Registro exitoso..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Update(GrupoDto entity)
        {
            var response = new Response<bool>();
            try
            {
                var grupo = _mapper.Map<Grupo>(entity);
                response.Data = _unitOfWork.Grupo.Update(grupo);
                if (response.Data)
                {
                    response.IsSucces = true;
                    response.Message = "Actualización exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Delete(int idGrupo)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _unitOfWork.Grupo.Delete(idGrupo);
                if (response.Data)
                {
                    response.IsSucces = true;
                    response.Message = "Eliminación exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<GrupoDto> Get(int idGrupo)
        {
            var response = new Response<GrupoDto>();
            try
            {
                var grupo = _unitOfWork.Grupo.Get(idGrupo);
                response.Data = _mapper.Map<GrupoDto>(grupo);
                if (response.Data != null)
                {
                    response.IsSucces = true;
                    response.Message = "Consulta exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<IEnumerable<GrupoDto>> GetAll()
        {
            var response = new Response<IEnumerable<GrupoDto>>();
            try
            {
                var grupos = _unitOfWork.Grupo.GetAll();
                response.Data = _mapper.Map<IEnumerable<GrupoDto>>(grupos);
                if (response.Data != null)
                {
                    response.IsSucces = true;
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

        public ResponsePagination<IEnumerable<GrupoDto>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<GrupoDto>>();
            try
            {
                var count = _unitOfWork.Grupo.Count();
                var customers = _unitOfWork.Grupo.GetAllWithPagination(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<GrupoDto>>(customers);
                if (response.Data != null)
                {
                    response.PageNumer = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;
                    response.IsSucces = true;
                    response.Message = "Consulta paginada exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

       
        #endregion

        #region Métodos Asíncronos
        public Task<Response<bool>> DeleteAsync(int grupoId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<GrupoDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponsePagination<IEnumerable<GrupoDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Response<GrupoDto>> GetAsync(int grupoId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> InsertAsync(GrupoDto gruposDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> UpdateAsync(GrupoDto gruposDto)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
