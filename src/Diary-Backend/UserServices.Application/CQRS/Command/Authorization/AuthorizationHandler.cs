using MediatR;

namespace UserServices.Application.CQRS.Command.Authorization
{
    public class AuthorizationHandler : IRequestHandler<AuthorizationCommand, string>
    {
        public Task<string> Handle(AuthorizationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
