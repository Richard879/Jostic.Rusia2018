using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Countrys.Commands.CreateCountryCommand
{
    public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCountryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            var validate = new Response<IEnumerable<CountryDto>>();
            var entity = _mapper.Map<Country>(request);
            var entityDto = await _unitOfWork.Countries.GetCountryValidate(entity);
            validate.Data = _mapper.Map<IEnumerable<CountryDto>>(entityDto);
            if (validate.Data != null)
            {
                response.Data = false;
                response.IsSuccess = true;
                response.Message = "Ya existe un registro con las mismas características..!!";
            }
            else
            {
                response.Data = await _unitOfWork.Countries.InsertAsync(entity);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso..!!";
                }
            }
            return response;
        }
    }
}