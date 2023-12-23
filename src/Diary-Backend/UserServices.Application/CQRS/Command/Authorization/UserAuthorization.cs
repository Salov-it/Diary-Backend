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
        public async Task<string> Authorization(UserLoginDto UserLoginDto)
        {
            //Получаем данные пользователя из бд
            var UserInfoContent = await _userRepository.GetByUserLogin(UserLoginDto);

            if(UserInfoContent.Login == UserLoginDto.Login && UserInfoContent.Password == UserInfoContent.Password)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name,UserLoginDto.Login),
                new Claim(ClaimTypes.Role,UserInfoContent.Role)};

                var jwt = new JwtSecurityToken(issuer: JwtSettings.Issuer,
                    audience: JwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(JwtSettings.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                var JwtToken = new JwtSecurityTokenHandler().WriteToken(jwt);
                var Content = JsonSerializer.Serialize(JwtToken);
                Result = Content;
            }
            else 
            {
                Result = "Ошибка";
            };
            return Result;
        }
    }
}
