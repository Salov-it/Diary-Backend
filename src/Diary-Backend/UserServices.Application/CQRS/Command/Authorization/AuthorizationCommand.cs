using MediatR;

namespace UserServices.Application.CQRS.Command.Authorization
{
    public class AuthorizationCommand : IRequest<string>
    {
    }
}
