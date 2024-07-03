namespace Jostic.Rusia2018.Application.Interface.Persistence
{
    public interface IRemovable<T> where T : class
    {
        #region Metodos Asíncronos
        Task<bool> DeleteAsync(int id);
        #endregion
    }
}