

namespace DatabasePostgres.Persistance.SqlRequest.UserSqlRequest
{
    public class UserSqlRequest
    {
       public string CreateUserTable = "CREATE TABLE Users (id SERIAL PRIMARY KEY, Login TEXT UNIQUE, Password TEXT, Phone TEXT, Created DATE);";
      
       public string DeleteUserTable = "DROP TABLE Users;";

        public string UserAdd = $"INSERT INTO Users (login,password,Phone,Created)" +
             "VALUES (@Login,@Password,@Phone,@Created)";

        public string GetAll = "SELECT Login,Passwords,Phone,Created FROM Users;";
    }
}
