using Usat.Ecommerce.Domain.Entity;
using Usat.Ecommerce.Domain.Interface;
using Usat.Ecommerce.Infraestructure.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Usat.Ecommerce.Domain.Core
{
    public class CustomersDomain : ICustomersDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomersDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Métodos Síncronos
        public bool Insert(Customer customers)
        {
            return _unitOfWork.Customers.Insert(customers);
        }
        public bool Update(Customer customer)
        {
            return _unitOfWork.Customers.Update(customer);
        }
        public bool Delete(string customerId)
        {
            return _unitOfWork.Customers.Delete(customerId);
        }
        public Customer Get(string customerId)
        {
            return _unitOfWork.Customers.Get(customerId);
        }
        public IEnumerable<Customer> GetAll()
        {
            return _unitOfWork.Customers.GetAll();
        }
        public IEnumerable<Customer> GetAllWithPagination(int pageNumber, int pageSize)
        {
            return _unitOfWork.Customers.GetAllWithPagination(pageNumber, pageSize);
        }
        public int Count()
        {
            return _unitOfWork.Customers.Count();
        }
        #endregion

        #region Métodos Asíncronos
        public async Task<bool> InsertAsync(Customer customers)
        {
            return await _unitOfWork.Customers.InsertAsync(customers);
        }
        public async Task<bool> UpdateAsync(Customer customers)
        {
            return await _unitOfWork.Customers.UpdateAsync(customers);
        }
        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _unitOfWork.Customers.DeleteAsync(customerId);
        }
        public async Task<Customer> GetAsync(string customerId)
        {
            return await _unitOfWork.Customers.GetAsync(customerId);
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _unitOfWork.Customers.GetAllAsync();
        }
        public async Task<IEnumerable<Customer>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Customers.GetAllWithPaginationAsync(pageNumber, pageSize);
        }
        public async Task<int> CountAsync()
        {
            return await _unitOfWork.Customers.CountAsync();
        }
        #endregion
    }
}
