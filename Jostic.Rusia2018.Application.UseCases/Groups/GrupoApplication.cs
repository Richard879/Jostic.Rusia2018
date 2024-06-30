using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Application.Interface.UseCases;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Transversal.Common;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace Jostic.Rusia2018.Application.UseCases.Grupos
{
    public class GrupoApplication : IGrupoApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public GrupoApplication(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _distributedCache = distributedCache;   
        }

        #region Métodos Síncronos
        public Response<bool> Insert(GroupDto entity)
        {
            var response = new Response<bool>();
            var grupo = _mapper.Map<Group>(entity);
            response.Data = _unitOfWork.Groups.Insert(grupo);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Registro exitoso..!!";
            }
            return response;
        }

        public Response<bool> Update(GroupDto entity)
        {
            var response = new Response<bool>();
            var grupo = _mapper.Map<Group>(entity);
            response.Data = _unitOfWork.Groups.Update(grupo);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Actualización exitosa..!!";
            }
            return response;
        }

        public Response<bool> Delete(int idGrupo)
        {
            var response = new Response<bool>();
            response.Data = _unitOfWork.Groups.Delete(idGrupo);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Eliminación exitosa..!!";
            }
            return response;
        }

        public Response<GroupDto> Get(int idGrupo)
        {
            var response = new Response<GroupDto>();
            var grupo = _unitOfWork.Groups.Get(idGrupo);
            response.Data = _mapper.Map<GroupDto>(grupo);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
            }
            return response;
        }

        public Response<IEnumerable<GroupDto>> GetAll()
        {
            var response = new Response<IEnumerable<GroupDto>>();
            var grupos = _unitOfWork.Groups.GetAll();
            response.Data = _mapper.Map<IEnumerable<GroupDto>>(grupos);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
            }
            return response;
        }

        public ResponsePagination<IEnumerable<GroupDto>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<GroupDto>>();
            var count = _unitOfWork.Groups.Count();
            var customers = _unitOfWork.Groups.GetAllWithPagination(pageNumber, pageSize);
            response.Data = _mapper.Map<IEnumerable<GroupDto>>(customers);
            if (response.Data != null)
            {
                response.PageNumer = pageNumber;
                response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                response.TotalCount = count;
                response.IsSuccess = true;
                response.Message = "Consulta paginada exitosa..!!";
            }
            return response;
        }


        #endregion

        #region Métodos Asíncronos
        public async Task<Response<bool>> InsertAsync(GroupDto entity)
        {
            var response = new Response<bool>();
            var grupo = _mapper.Map<Group>(entity);
            response.Data = await _unitOfWork.Groups.InsertAsync(grupo);
            if (response.Data)
            {
                await _distributedCache.RemoveAsync("grupoList");
                response.IsSuccess = true;
                response.Message = "Registro exitoso..!!";
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(GroupDto entity)
        {
            var response = new Response<bool>();
            var grupo = _mapper.Map<Group>(entity);
            response.Data = await _unitOfWork.Groups.UpdateAsync(grupo);
            if (response.Data)
            {
                await _distributedCache.RemoveAsync("grupoList");
                response.IsSuccess = true;
                response.Message = "Actualización exitosa..!!";
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int idGrupo)
        {
            var response = new Response<bool>();
            response.Data = await _unitOfWork.Groups.DeleteAsync(idGrupo);
            if (response.Data)
            {
                await _distributedCache.RemoveAsync("grupoList");
                response.IsSuccess = true;
                response.Message = "Eliminación exitosa..!!";
            }
            return response;
        }

        public async Task<Response<GroupDto>> GetAsync(int idGrupo)
        {
            var response = new Response<GroupDto>();
            var grupo = await _unitOfWork.Groups.GetAsync(idGrupo);
            response.Data = _mapper.Map<GroupDto>(grupo);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
            }
            return response;
        }

        public async Task<Response<IEnumerable<GroupDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<GroupDto>>();
            var cacheKey = "grupoList";
            TimeSpan? slidingExpiration = null;
            var redisGrupo = await _distributedCache.GetAsync(cacheKey);
            if (redisGrupo != null)
            {
                response.Data = JsonSerializer.Deserialize<IEnumerable<GroupDto>>(redisGrupo);
            }
            else
            {
                var grupos = await _unitOfWork.Groups.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<GroupDto>>(grupos);
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
            }
            return response;
        }

        public async Task<ResponsePagination<IEnumerable<GroupDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<GroupDto>>();
            var count = await _unitOfWork.Groups.CountAsync();
            var customers = await _unitOfWork.Groups.GetAllWithPaginationAsync(pageNumber, pageSize);
            response.Data = _mapper.Map<IEnumerable<GroupDto>>(customers);
            if (response.Data != null)
            {
                response.PageNumer = pageNumber;
                response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                response.TotalCount = count;
                response.IsSuccess = true;
                response.Message = "Consulta paginada exitosa..!!";
            }
            return response;
        }

        #endregion
    }
}