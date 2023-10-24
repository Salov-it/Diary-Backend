﻿using DatabasePostgres.Persistance.Config;
using DatabasePostgres.Persistance.Interface;
using DatabasePostgres.Persistance.SqlRequest.UserSqlRequest;
using UserServices.Domain;
using Npgsql;
using DatabasePostgres.Persistance.Dto;

namespace DatabasePostgres.Persistance.Repository
{
    public class UserRepositoryPostgres : IUserRepositoryPostgres
    {
        private readonly string _Connect;
        Configs configs = new Configs();
        UserSqlRequest _userSql = new UserSqlRequest();
        List<User> getAll = new List<User>();

        public UserRepositoryPostgres()
        {
            _Connect = configs.Connection;
        }
        public async Task<string> CreateTableUser()
        {
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_userSql.CreateUserTable))
            {
                await cmd.ExecuteNonQueryAsync();
            }
            return "Таблица Users создана успешно";
        }

        public async Task<string> UserAdd(string Login, string Password,string Phone, DateTime Create)
        {
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_userSql.UserAdd))
            {
                cmd.Parameters.AddWithValue("Login", Login);
                cmd.Parameters.AddWithValue("Password", Password);
                cmd.Parameters.AddWithValue("Phone", Phone);
                cmd.Parameters.AddWithValue("Role","User");
                cmd.Parameters.AddWithValue("Created", Create);
                await cmd.ExecuteNonQueryAsync();
            }
            return "Пользователь зарегистрирован успешно";
        }

        public async Task<string> UserUpdate(string Login,string Phone)
        {
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_userSql.UserUpdate))
            {
                cmd.Parameters.AddWithValue("Login", Login);
                cmd.Parameters.AddWithValue("Phone", Phone);
                await cmd.ExecuteNonQueryAsync();
            }
            return "Выполнено";
        }

        public UserInfoDto GetByUserInfoResult = new UserInfoDto();
        public async Task<UserInfoDto> GetByUserId(string Login)
        {
            
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_userSql.GetByUserInfo))
            {
                cmd.Parameters.AddWithValue("@login",Login);

                await using (var reader = await cmd.ExecuteReaderAsync())
                {

                    while (await reader.ReadAsync())
                    {
                        var login = reader.GetString(0);
                        var password = reader.GetString(1);

                        GetByUserInfoResult = new UserInfoDto
                        {
                            Login = login,
                            Password = password
                        };
                    }
                }
            }
            return GetByUserInfoResult;
        }

    }
}