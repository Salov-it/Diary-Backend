

namespace DatabasePostgres.Persistance.SqlRequest.UserSqlRequest
{
    public class UserSqlRequest
    {
       public string CreateUserTable = "CREATE TABLE Users (id SERIAL PRIMARY KEY, Login TEXT UNIQUE, Password TEXT, Phone TEXT,Role TEXT, Created DATE);";

        public string UserAdd = $"INSERT INTO Users (login,password,Phone,Role,Created)" +
             "VALUES ($1,$2,$3,$4,$5)";

        public string UserUpdate = "UPDATE Users SET phone = @Phone WHERE login = @Login;";

        public string GetByUserInfo = "SELECT login,password,Role FROM Users WHERE login = @login;";



    }
}
