

namespace DatabasePostgres.Persistance.Config
{
    public class Configs
    {
        public string Connection = $"Host={Host};Port={Port};Username={Login};Password={Password};Database={DatabaseName}";

        public static string Login = "postgres";
        public static string Password = "Salov1999";
        public static string DatabaseName = "DiaryBasse";
        public static string Host = "localhost";
        public static int Port = 5432;
    }
}
