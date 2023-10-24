using MediatR;
using UserServices.Application.Dto;

namespace UserServices.Application.CQRS.Command.Authorization
{
    public class AuthorizationCommand : IRequest<string>
    {
      public UserInfoDto UserInfo { get; set; }
    }
}
