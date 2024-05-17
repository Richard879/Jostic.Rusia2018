using Usat.Ecommerce.Domain.Entity;

namespace Usat.Ecommerce.Domain.Interface
{
    public interface ICustomersDomain
    {
        #region Metodos Sincronos
        bool Insert(Customer customers);
        bool Update(Customer customers);
        bool Delete(string customerId);
        Customer Get(string customerId);
        IEnumerable<Customer> GetAll();
        IEnumerable<Customer> GetAllWithPagination(int pageNumber, int pageSize);
        int Count();
        #endregion

        #region Metodos Asíncronos
        Task<bool> InsertAsync(Customer customers);
        Task<bool> UpdateAsync(Customer customers);
        Task<bool> DeleteAsync(string customerId);
        Task<Customer> GetAsync(string customerId);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<IEnumerable<Customer>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();
        #endregion
    }
}
