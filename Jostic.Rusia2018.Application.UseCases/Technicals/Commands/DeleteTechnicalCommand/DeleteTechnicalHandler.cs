using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Technicals.Commands.DeleteTechnicalCommand
{
    public class DeleteTechnicalHandler : IRequestHandler<DeleteTechnicalCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTechnicalHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Handle(DeleteTechnicalCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            response.Data = await _unitOfWork.Technicals.DeleteAsync(request.idTecnico);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Eliminación exitosa..!!";
            }
            return response;
        }
    }
}