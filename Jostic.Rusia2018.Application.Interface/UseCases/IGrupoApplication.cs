using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;

namespace Jostic.Rusia2018.Application.Interface.UseCases
{
    public interface IGrupoApplication
    {
        #region Metodos Sincronos
        Response<bool> Insert(GroupDto gruposDto);
        Response<bool> Update(GroupDto gruposDto);
        Response<bool> Delete(int idGrupo);
        Response<GroupDto> Get(int idGrupo);
        Response<IEnumerable<GroupDto>> GetAll();
        ResponsePagination<IEnumerable<GroupDto>> GetAllWithPagination(int pageNumber, int pageSize);
        #endregion

        #region Metodos Asíncronos
        Task<Response<bool>> InsertAsync(GroupDto gruposDto);
        Task<Response<bool>> UpdateAsync(GroupDto gruposDto);
        Task<Response<bool>> DeleteAsync(int idGrupo);
        Task<Response<GroupDto>> GetAsync(int idGrupo);
        Task<Response<IEnumerable<GroupDto>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<GroupDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        #endregion
    }
}
