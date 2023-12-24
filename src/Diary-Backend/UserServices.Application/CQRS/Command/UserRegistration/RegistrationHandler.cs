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
            return await _RegisterAsync.RegisterAsync(request.UserAdd);
        }
    }
}
