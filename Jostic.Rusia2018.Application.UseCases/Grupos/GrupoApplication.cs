using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Application.Interface.UseCases;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Transversal.Common;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text;

namespace Jostic.Rusia2018.Application.UseCases.Grupos
{
    public class GrupoApplication : IGrupoApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GrupoApplication> _logger;
        private readonly IDistributedCache _distributedCache;

        public GrupoApplication(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<GrupoApplication> logger, IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _distributedCache = distributedCache;   
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
                    response.IsSuccess = true;
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
                    response.IsSuccess = true;
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
                    response.IsSuccess = true;
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
                    response.IsSuccess = true;
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
                    response.IsSuccess = true;
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
        public async Task<Response<bool>> InsertAsync(GrupoDto entity)
        {
            var response = new Response<bool>();
            try
            {
                var grupo = _mapper.Map<Grupo>(entity);
                response.Data = await _unitOfWork.Grupo.InsertAsync(grupo);
                if (response.Data)
                {
                    await _distributedCache.RemoveAsync("grupoList");
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(GrupoDto entity)
        {
            var response = new Response<bool>();
            try
            {
                var grupo = _mapper.Map<Grupo>(entity);
                response.Data = await _unitOfWork.Grupo.UpdateAsync(grupo);
                if (response.Data)
                {
                    await _distributedCache.RemoveAsync("grupoList");
                    response.IsSuccess = true;
                    response.Message = "Actualización exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int idGrupo)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _unitOfWork.Grupo.DeleteAsync(idGrupo);
                if (response.Data)
                {
                    await _distributedCache.RemoveAsync("grupoList");
                    response.IsSuccess = true;
                    response.Message = "Eliminación exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<GrupoDto>> GetAsync(int idGrupo)
        {
            var response = new Response<GrupoDto>();
            try
            {
                var grupo = await _unitOfWork.Grupo.GetAsync(idGrupo);
                response.Data = _mapper.Map<GrupoDto>(grupo);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa..!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<GrupoDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<GrupoDto>>();
            var cacheKey = "grupoList";
            TimeSpan? slidingExpiration = null;

            try
            {
                var redisGrupo = await _distributedCache.GetAsync(cacheKey);
                if (redisGrupo != null)
                {
                    response.Data = JsonSerializer.Deserialize<IEnumerable<GrupoDto>>(redisGrupo);
                }
                else
                {
                    var grupos = await _unitOfWork.Grupo.GetAllAsync();
                    response.Data = _mapper.Map<IEnumerable<GrupoDto>>(grupos);
                    if (response.Data != null)
                    {
                        var serializerGrupo = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response.Data));
                        var cacheEntryOptions = new DistributedCacheEntryOptions
                        {
                            SlidingExpiration = slidingExpiration ?? TimeSpan.FromMinutes(30)
                        };
                        /*var options = new DistributedCacheEntryExtensions()
                            .SetAbsoluteExpiration(DateTime.Now.AddSeconds(10))
                        .SetSlidingExpiration(DateTime.Now.AddSeconds(5));*/

                        await _distributedCache.SetAsync(cacheKey, serializerGrupo, cacheEntryOptions);
                    }
                }

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

        public async Task<ResponsePagination<IEnumerable<GrupoDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<GrupoDto>>();
            try
            {
                var count = await _unitOfWork.Grupo.CountAsync();
                var customers = await _unitOfWork.Grupo.GetAllWithPaginationAsync(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<GrupoDto>>(customers);
                if (response.Data != null)
                {
                    response.PageNumer = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;
                    response.IsSuccess = true;
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
    }
}