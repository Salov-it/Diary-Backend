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
            var Validation = new AuthorizationCommandValidation();
            var validationResult = Validation.Validate(request);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    return error.ErrorMessage;
                }
            }

            var Content = await _userAuthorization.Authorization(request.UserAutDto);
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
