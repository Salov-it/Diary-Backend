
using UserServices.Application.Dto;

namespace UserServices.Application.Interface
{
    public interface IUserAuthorization
    {
        Task<UserInfoDto> Authorization(UserInfoDto userInfoDto);
    }
}
