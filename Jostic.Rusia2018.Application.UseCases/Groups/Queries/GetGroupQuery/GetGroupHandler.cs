using AutoMapper;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Groups.Queries.GetGrupoQuery
{
    public class GetGroupHandler : IRequestHandler<GetGroupQuery, Response<GroupDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGroupHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<GroupDto>> Handle(GetGroupQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<GroupDto>();
            var entity = await _unitOfWork.Groups.GetAsync(request.idGrupo);
            response.Data = _mapper.Map<GroupDto>(entity);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Consulta exitosa..!!";
            }
            return response;
        }
    }
}