using MediatR;

namespace UserServices.Application.CQRS.Command.UserRegistration
{
    public class RegistrationHandler : IRequestHandler<RegistrationCommand, string>
    {
        public Task<string> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
