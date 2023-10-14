using DatabasePostgres.Persistance.Config;
using DatabasePostgres.Persistance.Interface;
using DatabasePostgres.Persistance.SqlRequest.UserSqlRequest;
using Npgsql;

namespace DatabasePostgres.Persistance.Repository
{
    public class UserRepositoryPostgres : IUserRepositoryPostgres
    {
        private readonly string _Connect;
        Configs configs = new Configs();
        UserSqlRequest _userSql = new UserSqlRequest();

       public UserRepositoryPostgres()
        {
            _Connect = configs.Connection;
        }
        public async void CreateTableUser()
        {
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_userSql.CreateUserTable))
            {
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async void DeleteTableUser()
        {
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_userSql.DeleteUserTable))
            {
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async void UserAdd(string Login, string Password, int Phone, DateTime Create, DateTime Update)
        {
            await using var dataSource = NpgsqlDataSource.Create(_Connect);
            await using (var cmd = dataSource.CreateCommand(_userSql.UserAdd))
            {
                cmd.Parameters.AddWithValue("Login", Login);
                cmd.Parameters.AddWithValue("Password", Password);
                cmd.Parameters.AddWithValue("Phone", Phone);
                cmd.Parameters.AddWithValue("Create", Create);
                cmd.Parameters.AddWithValue("Update", Update);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public void UserUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
