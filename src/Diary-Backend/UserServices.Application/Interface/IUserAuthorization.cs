using UserServices.Application.Dto;

namespace UserServices.Application.Interface
{
    public interface IUserAuthorization
    {
        Task<string>Authorization(UserInfoDto userInfoDto);
    }
}
