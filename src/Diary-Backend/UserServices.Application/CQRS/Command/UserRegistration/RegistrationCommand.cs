using MediatR;
using UserDto.Dto;

namespace UserServices.Application.CQRS.Command.UserRegistration
{
    public class RegistrationCommand : IRequest<string>
    {
        public UserAddDto UserAdd { get; set; }
    }
}
