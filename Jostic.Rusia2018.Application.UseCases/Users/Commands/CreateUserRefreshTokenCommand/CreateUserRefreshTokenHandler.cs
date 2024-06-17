using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Users.Commands.CreateUserRefreshTokenCommand
{
    public class CreateUserRefreshTokenHandler : IRequestHandler<CreateUserRefreshTokenQuery, Response<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserRefreshTokenHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<UserDto>> Handle(CreateUserRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<UserDto>();
            var user = new User();
            user.UserId = request.UserId;


            response.Data = _mapper.Map<UserDto>(user);
            response.IsSuccess = true;
            response.Message = "Autenticación Exitosa!!!";

            return response;
        }
    }
}
