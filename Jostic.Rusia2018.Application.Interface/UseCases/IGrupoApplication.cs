using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;

namespace Jostic.Rusia2018.Application.Interface.UseCases
{
    public interface IGrupoApplication
    {
        #region Metodos Sincronos
        Response<bool> Insert(GrupoDto gruposDto);
        Response<bool> Update(GrupoDto gruposDto);
        Response<bool> Delete(int idGrupo);
        Response<GrupoDto> Get(int idGrupo);
        Response<IEnumerable<GrupoDto>> GetAll();
        ResponsePagination<IEnumerable<GrupoDto>> GetAllWithPagination(int pageNumber, int pageSize);
        #endregion

        #region Metodos Asíncronos
        Task<Response<bool>> InsertAsync(GrupoDto gruposDto);
        Task<Response<bool>> UpdateAsync(GrupoDto gruposDto);
        Task<Response<bool>> DeleteAsync(int idGrupo);
        Task<Response<GrupoDto>> GetAsync(int idGrupo);
        Task<Response<IEnumerable<GrupoDto>>> GetAllAsync();
        Task<ResponsePagination<IEnumerable<GrupoDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        #endregion
    }
}
