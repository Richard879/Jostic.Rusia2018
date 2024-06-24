using FluentValidation;

namespace Jostic.Rusia2018.Application.UseCases.Groups.Commands.CreateGrupoCommand
{
    public class CreateGroupValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupValidator() {
            RuleFor(g => g.descripcion).NotNull().NotEmpty();
        }
    }
}