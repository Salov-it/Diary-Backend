using UserServices.Application.Interface;
using DatabasePostgres.Persistance.Interface;
using System.IdentityModel.Tokens.Jwt;
using UserServices.Application.Config;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text.Json;
using UserDto.Dto;



namespace UserServices.Application.CQRS.Command.Authorization
{
    public class UserAuthorization : IUserAuthorization
    {
        private readonly IUserRepositoryPostgres _userRepository;
        
        public UserAuthorization(IUserRepositoryPostgres userRepository)
        {
            _userRepository = userRepository;
        }

        public string Result { get; set; }
        public async Task<string> Authorization(UserAutDto UserAut)
        {
            //Получаем данные пользователя из бд
            var UserInfoContent = await _userRepository.GetAllUser();
            var UserContent = UserInfoContent.FirstOrDefault(u => u.Login == UserAut.Login);
            if (UserContent == null)
            {
                return "Ошибка: неверный логин";
            }
            else
            {
                if (UserContent.Login == UserAut.Login && UserAut.Password == UserContent.Password)
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name,UserAut.Login),
                    new Claim(ClaimTypes.Role,UserContent.Role)};

                    var jwt = new JwtSecurityToken(issuer: JwtSettings.Issuer,
                        audience: JwtSettings.Audience,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                        signingCredentials: new SigningCredentials(JwtSettings.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                    var JwtToken = new JwtSecurityTokenHandler().WriteToken(jwt);
                    var Content = JsonSerializer.Serialize(JwtToken);
                    Result = Content;
                }
                else { Result =  "Ошибка: Неверный пароль"; }
            }

            return Result;
        }
    }
}
