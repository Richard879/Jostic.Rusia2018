﻿using AutoMapper;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Continents.Commands.CreateContinentCommand
{
    public class CreateContinentHandler : IRequestHandler<CreateContinentCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateContinentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateContinentCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            var entity = _mapper.Map<Continent>(request);
            response.Data = await _unitOfWork.Continents.InsertAsync(entity);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Registro exitoso..!!";
            }
            return response;
        }
    }
}