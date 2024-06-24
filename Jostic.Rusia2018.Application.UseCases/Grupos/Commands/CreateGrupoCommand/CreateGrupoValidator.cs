using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jostic.Rusia2018.Application.UseCases.Grupos.Commands.CreateGrupoCommand
{
    public class CreateGrupoValidator : AbstractValidator<CreateGrupoCommand>
    {
        public CreateGrupoValidator() {
            RuleFor(g => g.descripcion).NotNull().NotEmpty();
        }
    }
}