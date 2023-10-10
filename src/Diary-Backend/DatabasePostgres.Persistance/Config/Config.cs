

namespace DatabasePostgres.Persistance.Config
{
    public class Config
    {
        public string Connection = $"Host={Host};Username={Login};Password={Password};Database={DatabaseName}";

        public static string Login = "";
        public static string Password = "";
        public static string DatabaseName = "";
        public static string Host = "localhost";
    }
}
