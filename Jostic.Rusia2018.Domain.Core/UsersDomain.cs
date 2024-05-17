using Usat.Ecommerce.Domain.Entity;
using Usat.Ecommerce.Domain.Interface;
using Usat.Ecommerce.Infraestructure.Interface;

namespace Usat.Ecommerce.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Authenticate(string username, string password)
        {
            return _unitOfWork.Users.Authenticate(username, password);
        }
    }
}
