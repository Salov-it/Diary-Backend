using MediatR;

namespace UserServices.Application.CQRS.Command.UserRegistration
{
    public class RegistrationCommand : IRequest<string>
    {
    }
}
