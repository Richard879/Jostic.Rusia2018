using FluentValidation;

namespace Jostic.Rusia2018.Application.UseCases.Users.Commands.CreateUserTokenCommand
{
    public class CreateUserTokenValidator : AbstractValidator<CreateUserTokenCommand>
    {
        public CreateUserTokenValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty().MinimumLength(5);
        }
    }
}