﻿

namespace DatabasePostgres.Persistance.SqlRequest.UserSqlRequest
{
    public class UserSqlRequest
    {
       public string CreateUserTable = "CREATE TABLE Users (id int PRIMARY KEY,Login TEXT,Password TEX,Phone TEXT,Create DATE,Update DATE);";
      
       public string DeleteUserTable = "DROP TABLE Users;";

        public string UserAdd = $"INSERT INTO Users (login,password,INSERT INTO Users (login,password,Phone,Create,Update)" +
             "VALUES (@Login,@Password,@Phone,@Create,@Update))";
    }
}
