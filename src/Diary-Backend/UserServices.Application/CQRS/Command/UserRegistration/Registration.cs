using DatabasePostgres.Persistance.Interface;
using UserDto.Dto;
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
        public async Task<string> RegisterAsync(UserAddDto UserAdd)
        {
            var User = await _userRepositoryPostgres.GetAllUser();
            
            var UserContent = User.FirstOrDefault(u => u.Login == UserAdd.Login || u.Phone == UserAdd.Phone);

            if(UserContent == null)
            {
                return await _userRepositoryPostgres.UserAdd(UserAdd);
            }
            else
            {
                if (UserContent.Login == UserAdd.Login)
                {
                    return "Пользователь уже существует";
                }
                else
                {
                    if (UserContent.Phone == UserAdd.Phone)
                    {
                        return "Номер телефона уже зарегистрирован";
                    }
                    else { return await _userRepositoryPostgres.UserAdd(UserAdd); }
                }
    
            }
        }
    } 
}
