using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Transversal.Common;

namespace Jostic.Rusia2018.Application.Interface.UseCases
{
    public interface IPaisApplication
    {
        #region Metodos Sincronos
        Response<bool> Insert(CountryDto paisDto);
        Response<bool> Update(CountryDto paisDto);
        Response<bool> Delete(int idPais);
        Response<CountryDto> Get(int idPais);
        Response<IEnumerable<CountryDto>> GetAll();
        Response<IEnumerable<CountryDto>> GetPaisesAll();
        ResponsePagination<IEnumerable<CountryDto>> GetAllWithPagination(int pageNumber, int pageSize);
        #endregion

        #region Metodos Asíncronos
        Task<Response<bool>> InsertAsync(CountryDto paisDto);
        Task<Response<bool>> UpdateAsync(CountryDto paisDto);
        Task<Response<bool>> DeleteAsync(int idPais);
        Task<Response<CountryDto>> GetAsync(int idPais);
        Task<Response<IEnumerable<CountryDto>>> GetAllAsync();
        Task<Response<IEnumerable<CountryDto>>> GetPaisesAllAsync();
        Task<ResponsePagination<IEnumerable<CountryDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        #endregion
    }
}
