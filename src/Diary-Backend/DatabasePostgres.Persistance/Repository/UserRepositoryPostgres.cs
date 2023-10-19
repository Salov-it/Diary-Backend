using DatabasePostgres.Persistance.Config;
using DatabasePostgres.Persistance.Interface;
using DatabasePostgres.Persistance.SqlRequest.UserSqlRequest;
using UserServices.Domain;
using Npgsql;

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

        public async void DeleteTableUser()
        {
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_userSql.DeleteUserTable))
            {
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<string> UserAdd(string Login, string Password, int Phone, DateTime Create)
        {
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_userSql.UserAdd))
            {
                cmd.Parameters.AddWithValue("Login", Login);
                cmd.Parameters.AddWithValue("Password", Password);
                cmd.Parameters.AddWithValue("Phone", Phone);
                cmd.Parameters.AddWithValue("Create", Create);
                await cmd.ExecuteNonQueryAsync();
            }
            return "Пользователь зарегистрирован успешно";
        }

        public void UserUpdate()
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAll()
        {
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_userSql.GetAll))
            {
                await using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var login = reader.GetString(0);
                    var password = reader.GetString(1);
                    var phone = reader.GetInt16(2);
                    ;
                    User Content = new User
                    {
                        Login = login,
                        Password = password,
                        Phone = phone,


                    };
                    getAll.Add(Content);
                }
            }
            return getAll;
        }

    }
}