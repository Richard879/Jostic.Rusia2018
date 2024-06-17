using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Users.Commands.CreateUserTokenCommand
{
    public class CreateUserTokenHandler : IRequestHandler<CreateUserTokenQuery, Response<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserTokenHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //private readonly UserDtoValidator _validator;

        public async Task<Response<UserDto>> Handle(CreateUserTokenQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<UserDto>();
            var user = await _unitOfWork.Users.Authenticate(request.UserName, request.Password);

            if (user is null)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
                return response;
            }

            response.Data = _mapper.Map<UserDto>(user);
            response.IsSuccess = true;
            response.Message = "Autenticación Exitosa!!!";

            return response;
        }

    }
}