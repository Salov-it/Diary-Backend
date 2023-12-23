using MediatR;
using UserServices.Application.Interface;

namespace UserServices.Application.CQRS.Command.UserRegistration
{
    public class RegistrationHandler : IRequestHandler<RegistrationCommand, string>
    {
        private readonly IRegistration _RegisterAsync;
        public string Resullt { get; set; }
        public RegistrationHandler(IRegistration registration)
        {
            _RegisterAsync = registration;
        }
        public async Task<string> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var Content = await _RegisterAsync.RegisterAsync(request.UserAdd);

            if (Content != null)
            {
                Resullt = "200";
            }
            else
            {
                Resullt = "500";
            }
            return Resullt;
        }
    }
}
