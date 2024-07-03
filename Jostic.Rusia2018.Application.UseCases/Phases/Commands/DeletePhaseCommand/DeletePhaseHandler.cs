using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Phases.Commands.DeletePhaseCommand
{
    public class DeletePhaseHandler : IRequestHandler<DeletePhaseCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePhaseHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Handle(DeletePhaseCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            response.Data = await _unitOfWork.Phases.DeleteAsync(request.idFase);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Eliminación exitosa..!!";
            }
            return response;
        }
    }
}