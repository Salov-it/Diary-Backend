using DatabasePostgres.Persistance.Dto;
using UserDto.Dto;


namespace DatabasePostgres.Persistance.Interface
{
    public interface IUserRepositoryPostgres
    {
        Task<string> CreateTableUser();
        Task<string> UserAdd(UserAddDto userAdd);
        Task<UserInfoDto> GetByUserLogin(UserLoginDto UserLoginDto);
        
    }
}
