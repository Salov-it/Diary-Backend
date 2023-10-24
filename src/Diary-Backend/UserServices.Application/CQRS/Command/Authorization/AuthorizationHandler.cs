using MediatR;
using UserServices.Application.Interface;

namespace UserServices.Application.CQRS.Command.Authorization
{
    public class AuthorizationHandler : IRequestHandler<AuthorizationCommand, string>
    {
        private readonly IUserAuthorization _userAuthorization;

        public AuthorizationHandler(IUserAuthorization userAuthorization)
        {
            _userAuthorization = userAuthorization;
        }
        public async Task<string> Handle(AuthorizationCommand request, CancellationToken cancellationToken)
        {
            var Content = await _userAuthorization.Authorization(request.UserInfo);
            return Content;
        }
    }
}
