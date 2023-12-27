using FluentValidation;

namespace UserServices.Application.CQRS.Command.Authorization
{
    public class AuthorizationCommandValidation : AbstractValidator<AuthorizationCommand>
    {
       public AuthorizationCommandValidation()
        {
            RuleFor(AuthorizationCommand => AuthorizationCommand.UserAutDto.Login)
          .NotEmpty().WithMessage("Требуется Login.")
          .Length(3, 20).WithMessage("Login должен содержать от 3 до 20 символов.");

            RuleFor(AuthorizationCommand => AuthorizationCommand.UserAutDto.Password)
           .NotEmpty().WithMessage("Требуется Password.")
           .Length(5, 16).WithMessage("Пароль должен содержать от 5 до 16 символов.");
        }
    }
}
