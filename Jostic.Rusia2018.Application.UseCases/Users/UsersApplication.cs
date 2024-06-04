using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Application.Interface.UseCases;
using Jostic.Rusia2018.Application.Validator;
using Jostic.Rusia2018.Transversal.Common;

namespace Jostic.Rusia2018.Application.UseCases.Users
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserDtoValidator _validator;

        public UsersApplication(IUnitOfWork unitOfWork, IMapper mapper, UserDtoValidator validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public Response<UserDto> Authenticate(string username, string password)
        {
            var response = new Response<UserDto>();
            var validation = _validator.Validate(new UserDto() { UserName = username, Password = password });
            if (!validation.IsValid)
            {
                response.Message = "Errores de validación";
                response.Errors = validation.Errors;
                return response;
            }

            try
            {
                var user = _unitOfWork.Users.Authenticate(username, password);
                response.Data = _mapper.Map<UserDto>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación Exitosa!!!";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe!!!";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
