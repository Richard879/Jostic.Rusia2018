namespace Jostic.Rusia2018.Application.Interface.Persistence
{
    public interface IReadable<T> where T : class
    {
        #region Metodos Asíncronos
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();
        #endregion
    }
}