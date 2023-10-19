

using UserServices.Application.Dto;

namespace UserServices.Application.Interface
{
    public interface IRegistration
    {
        Task<string> RegisterAsync(RegistrationResponseDto registrationResponseDto);
    }
}
