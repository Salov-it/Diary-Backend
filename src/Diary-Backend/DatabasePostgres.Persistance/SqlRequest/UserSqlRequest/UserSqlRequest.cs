

namespace DatabasePostgres.Persistance.SqlRequest.UserSqlRequest
{
    public class UserSqlRequest
    {
       public string CreateUserTable = "CREATE TABLE Users (id SERIAL PRIMARY KEY, Login TEXT UNIQUE, Password TEXT, Phone TEXT,Role TEXT, Created DATE);";

        public string UserAdd = $"INSERT INTO Users (login,password,Phone,Role,Created)" +
             "VALUES (@Login,@Password,@Phone,@Role,@Created)";

        public string UserUpdate = "UPDATE Users SET phone = @Phone WHERE login = @Login;";

        public string GetByUserInfo = "SELECT login,password FROM Users WHERE login = @login;";



    }
}
