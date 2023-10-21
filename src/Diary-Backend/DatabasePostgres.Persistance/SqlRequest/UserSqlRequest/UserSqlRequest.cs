

namespace DatabasePostgres.Persistance.SqlRequest.UserSqlRequest
{
    public class UserSqlRequest
    {
       public string CreateUserTable = "CREATE TABLE Users (id SERIAL PRIMARY KEY, Login TEXT UNIQUE, Password TEXT, Phone TEXT, Created DATE);";

        public string UserAdd = $"INSERT INTO Users (login,password,Phone,Created)" +
             "VALUES (@Login,@Password,@Phone,@Created)";

        public string UserUpdate = "UPDATE Users SET phone = @Phone WHERE login = @Login;";



    }
}
