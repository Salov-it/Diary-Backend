using MediatR;
using UserDto.Dto;

namespace UserServices.Application.CQRS.Command.Authorization
{
    public class AuthorizationCommand : IRequest<string>
    {
      public UserAutDto UserAutDto { get; set; }
    }
}
