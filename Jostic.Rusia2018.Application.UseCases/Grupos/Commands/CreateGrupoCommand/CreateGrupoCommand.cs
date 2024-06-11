using Jostic.Rusia2018.Transversal.Common;
using MediatR;

namespace Jostic.Rusia2018.Application.UseCases.Grupos.Commands.CreateGrupoCommand
{
    public sealed record CreateGrupoCommand : IRequest<Response<bool>>
    {
        public string descripcion { get; set; } = string.Empty;
    }
}