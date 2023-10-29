using UserServices.Application.Interface;
using DatabasePostgres.Persistance.Interface;
using UserServices.Application.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using UserServices.Application.Config;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text.Json;



namespace UserServices.Application.CQRS.Command.Authorization
{
    public class UserAuthorization : IUserAuthorization
    {
        private readonly IUserRepositoryPostgres _userRepository;
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
                var claims = new List<Claim> { new Claim(ClaimTypes.Name,userInfoDto.Login),
                new Claim(ClaimTypes.Role,UserInfoContent.Role)};

                var jwt = new JwtSecurityToken(issuer: JwtSettings.Issuer,
                    audience: JwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(JwtSettings.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                _userJwtToken.JwtToken = new JwtSecurityTokenHandler().WriteToken(jwt);
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
