using UserServices.Application.Interface;
using DatabasePostgres.Persistance.Interface;
using UserServices.Application.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using UserServices.Application.Config;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text.Json;
using System.Net;

namespace UserServices.Application.CQRS.Command.Authorization
{
    public class UserAuthorization : IUserAuthorization
    {
        private readonly IUserRepositoryPostgres _userRepository;
        JwtSettings jwtSettings = new JwtSettings();
        UserJwtToken _userJwtToken = new UserJwtToken();

        public UserAuthorization(IUserRepositoryPostgres userRepository)
        {
            _userRepository = userRepository;
        }

        public string Result { get; set; }
        public async Task<string> Authorization(UserInfoDto userInfoDto)
        {
            //Получаем данные пользователя из бд
            var UserInfoContent = await _userRepository.GetByUserId(userInfoDto.Login);

            if(UserInfoContent.Login == userInfoDto.Login && UserInfoContent.Password == userInfoDto.Password)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(jwtSettings.Key);

                var payload = new JwtPayload
                {
                    {"name", UserInfoContent.Login},
                    {"role", UserInfoContent.Role}
                };
                
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, UserInfoContent.Login),
                       
                    }),

                    Expires = DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings.DurationInMinutes.ToString())),
                };
                var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                var header = new JwtHeader(credentials);
                var token = new JwtSecurityToken(header, payload);

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

               _userJwtToken.JwtToken = tokenString;
               var Content = JsonSerializer.Serialize(_userJwtToken);
               Result = Content;
            }
            else 
            {
                _userJwtToken.Error = "Error Authorization 401";
                var Content = JsonSerializer.Serialize(_userJwtToken);
                Result = Content;
            };
            return Result;
        }
    }
}
