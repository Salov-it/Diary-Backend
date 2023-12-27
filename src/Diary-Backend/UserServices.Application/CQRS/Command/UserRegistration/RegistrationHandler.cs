using MediatR;
using UserServices.Application.Interface;

namespace UserServices.Application.CQRS.Command.UserRegistration
{
    public class RegistrationHandler : IRequestHandler<RegistrationCommand, string>
    {
        private readonly IRegistration _RegisterAsync;
        public RegistrationHandler(IRegistration registration)
        {
            _RegisterAsync = registration;
        }
        public async Task<string> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var Validation = new RegistrationCommandValidation();
            var validationResult = Validation.Validate(request);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    return error.ErrorMessage;
                }
            }

            var Content = await _RegisterAsync.RegisterAsync(request.UserAdd);

            if (Content != null)
            {
                return Content;
            }
            else
            {
                return "Ошибка";
            }
               
        }
    }
}
