using FluentValidation;

namespace UserServices.Application.CQRS.Command.UserRegistration
{
   public class RegistrationCommandValidation : AbstractValidator<RegistrationCommand>
   {
      public RegistrationCommandValidation() 
      {
            RuleFor(RegistrationCommand => RegistrationCommand.UserAdd.Login)
           .NotEmpty().WithMessage("Требуется Login.")
           .Length(3, 20).WithMessage("Login должен содержать от 3 до 20 символов.");

            RuleFor(RegistrationCommand => RegistrationCommand.UserAdd.Password)
           .NotEmpty().WithMessage("Требуется Password.")
           .Length(5, 16).WithMessage("Пароль должен содержать от 5 до 16 символов.");

            RuleFor(RegistrationCommand => RegistrationCommand.UserAdd.Phone)
           .NotEmpty().WithMessage("Требуется номер телефона.")
           .Must(BeValidRussianPhoneNumber).WithMessage("Некорректный номер телефона.");

            RuleFor(RegistrationCommand => RegistrationCommand.UserAdd.Role)
             .NotEmpty().WithMessage("Требуется указать роль.")
             .Must(BeValidRole).WithMessage("Некорректная роль.");

            RuleFor(RegistrationCommand => RegistrationCommand.UserAdd.Created)
                .NotNull().WithMessage("Требуется Created.")
                .LessThan(DateTime.Now).WithMessage("Дата создания не может быть в будущем.");
      }
        private bool BeValidRussianPhoneNumber(string phoneNumber)
        {
            // Пример: простая проверка наличия 11 цифр (стандартный формат российского номера)
            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length == 11 && phoneNumber.All(char.IsDigit);
        }

        private bool BeValidRole(string role)
        {
            // Предположим, у вас есть определенные допустимые роли (например, "Admin", "User", "Guest")
            string[] validRoles = { "Admin", "User"};
            return !string.IsNullOrEmpty(role) && validRoles.Contains(role);
        }

    }
}
