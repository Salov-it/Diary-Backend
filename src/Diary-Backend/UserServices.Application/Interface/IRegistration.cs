using UserDto.Dto;

namespace UserServices.Application.Interface
{
    public interface IRegistration
    {
        Task<string> RegisterAsync(UserAddDto userAdd);
    }
}
