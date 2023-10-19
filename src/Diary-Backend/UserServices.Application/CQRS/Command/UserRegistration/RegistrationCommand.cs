using MediatR;
using UserServices.Application.Dto;

namespace UserServices.Application.CQRS.Command.UserRegistration
{
    public class RegistrationCommand : IRequest<string>
    {
        public RegistrationResponseDto registrationDto { get; set; }
    }
}
