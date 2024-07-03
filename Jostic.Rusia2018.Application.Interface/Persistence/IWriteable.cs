namespace Jostic.Rusia2018.Application.Interface.Persistence
{
    public interface IWriteable<T> where T : class
    {
        #region Metodos Asíncronos
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        #endregion
    }
}