using DatabasePostgres.Persistance.Interface;
using UserDto.Dto;
using UserServices.Application.Dto;
using UserServices.Application.Interface;

namespace UserServices.Application.CQRS.Command.UserRegistration
{
    public class Registration : IRegistration
    {
        private readonly IUserRepositoryPostgres _userRepositoryPostgres;
        private readonly string _RegistrationResponseDto;
        public string Resullt { get; set; }
       
        public Registration(IUserRepositoryPostgres userRepositoryPostgres)
        {
            _userRepositoryPostgres = userRepositoryPostgres;
           
        }
        public async Task<string> RegisterAsync(UserAddDto userAdd)
        {
            
            return  await _userRepositoryPostgres.UserAdd(userAdd);  
        }
    }
}
