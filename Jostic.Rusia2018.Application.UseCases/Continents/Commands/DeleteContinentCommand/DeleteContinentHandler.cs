using Jostic.Rusia2018.Application.Interface.Persistence;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Continents.Commands.DeleteContinentCommand
{
    public class DeleteContinentHandler : IRequestHandler<DeleteContinentCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteContinentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Handle(DeleteContinentCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            response.Data = await _unitOfWork.Continents.DeleteAsync(request.idContinente);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Eliminación exitosa..!!";
            }
            return response;
        }
    }
}