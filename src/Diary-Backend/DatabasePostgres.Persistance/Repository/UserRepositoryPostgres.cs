using DatabasePostgres.Persistance.Config;
using DatabasePostgres.Persistance.Interface;
using DatabasePostgres.Persistance.SqlRequest.UserSqlRequest;
using Npgsql;
using UserDto.Dto;

namespace DatabasePostgres.Persistance.Repository
{
    public class UserRepositoryPostgres : IUserRepositoryPostgres
    {
        private readonly string _Connect;
        Configs configs = new Configs();
        UserSqlRequest _userSql = new UserSqlRequest();
        UserInfoDto _UserInfoDto = new UserInfoDto();

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
            return "200";
        }

        public async Task<string> UserAdd(UserAddDto userAdd)
        {
            await using var conn = new NpgsqlConnection(_Connect);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(_userSql.UserAdd, conn)
            {
                Parameters =
                {
                    new() { Value = userAdd.Login},
                    new() { Value = userAdd.Password },
                    new() { Value = userAdd.Phone },
                    new() { Value = userAdd.Created }
                }
            };
            await cmd.ExecuteNonQueryAsync();
            return "200";
        }

        public async Task<UserInfoDto> GetByUserLogin(UserLoginDto UserLoginDto)
        {
            
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_userSql.GetByUserInfo))
            {
                cmd.Parameters.AddWithValue("@Login",UserLoginDto.Login);

                await using (var reader = await cmd.ExecuteReaderAsync())
                {

                    while (await reader.ReadAsync())
                    {
                        var login = reader.GetString(0);
                        var password = reader.GetString(1);
                        var role = reader.GetString(2);
                        UserInfoDto UserInfo = new UserInfoDto
                        {
                            Login = login,
                            Password = password,
                            Role = role
                        };
                        _UserInfoDto = UserInfo;
                    }
                }
            }
            return _UserInfoDto;
        }

    }
}