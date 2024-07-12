using FluentValidation;

namespace Jostic.Rusia2018.Application.UseCases.Countrys.Commands.CreateCountryCommand
{
    public class CreateCountryValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryValidator()
        {
            RuleFor(g => g.nomPais).NotNull().NotEmpty();
            RuleFor(g => g.tecnico.idTecnico).NotNull().NotEmpty().NotEqual(0);
            RuleFor(g => g.grupo.idGrupo).NotNull().NotEmpty().NotEqual(0);
            RuleFor(g => g.continente.idContinente).NotNull().NotEmpty().NotEqual(0);
        }
    }
}