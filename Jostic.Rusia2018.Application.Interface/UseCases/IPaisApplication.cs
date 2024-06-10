using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;

namespace Jostic.Rusia2018.Application.Interface.UseCases
{
    public interface IPaisApplication
    {
        #region Metodos Sincronos
        Response<bool> Insert(PaisDto paisDto);
        Response<bool> Update(PaisDto paisDto);
        Response<bool> Delete(int idPais);
        Response<PaisDto> Get(int idPais);
        Response<IEnumerable<PaisDto>> GetAll();
        Response<List<PaisDto>> GetPaises();
        ResponsePagination<IEnumerable<PaisDto>> GetAllWithPagination(int pageNumber, int pageSize);
        #endregion

        #region Metodos Asíncronos
        Task<Response<bool>> InsertAsync(PaisDto paisDto);
        Task<Response<bool>> UpdateAsync(PaisDto paisDto);
        Task<Response<bool>> DeleteAsync(int idPais);
        Task<Response<PaisDto>> GetAsync(int idPais);
        Task<Response<IEnumerable<PaisDto>>> GetAllAsync();
        Task<Response<List<PaisDto>>> GetPaisesAsync();
        Task<ResponsePagination<IEnumerable<PaisDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        #endregion
    }
}
