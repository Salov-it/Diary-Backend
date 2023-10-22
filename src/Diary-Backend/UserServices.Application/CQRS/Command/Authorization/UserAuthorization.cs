using UserServices.Application.Interface;
using DatabasePostgres.Persistance.Interface;
using UserServices.Application.Dto;

namespace UserServices.Application.CQRS.Command.Authorization
{
    public class UserAuthorization : IUserAuthorization
    {
        private readonly IUserRepositoryPostgres _userRepository;

        public UserAuthorization(IUserRepositoryPostgres userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserInfoDto> Authorization(UserInfoDto userInfoDto)
        {
            //Получаем данные пользователя из бд
            var UserInfoContent = await _userRepository.GetByUserId(userInfoDto.Login);
            
        }
    }
}
