

namespace DatabasePostgres.Persistance.SqlRequest.UserSqlRequest
{
    public class UserSqlRequest
    {
        public class Create
        {
            string CreateUserTable = "CREATE TABLE Users (id int PRIMARY KEY,Login TEXT,Password TEX,Phone TEXT,Create DATE,Update DATE);";
        }
    }
}
