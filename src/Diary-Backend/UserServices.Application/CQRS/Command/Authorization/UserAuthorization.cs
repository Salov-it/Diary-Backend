﻿using UserServices.Application.Interface;
using DatabasePostgres.Persistance.Interface;
using UserServices.Application.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using UserServices.Application.Config;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace UserServices.Application.CQRS.Command.Authorization
{
    public class UserAuthorization : IUserAuthorization
    {
        private readonly IUserRepositoryPostgres _userRepository;
        JwtSettings jwtSettings = new JwtSettings();

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
                var key = Encoding.ASCII.GetBytes(jwtSettings.Key);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, UserInfoContent.Login)
                    }),

                    Expires = DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings.DurationInMinutes.ToString())),

                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                Result = tokenString;
            }
            else { Result = "Ошибка авторизации 401" };

            return Result;
        }
    }
}
