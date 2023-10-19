

namespace DatabasePostgres.Persistance.Config
{
    public class Configs
    {
        public string Connection = $"Host={Host};Port={Port};Username={Login};Password={Password};Database={DatabaseName}";

        public static string Login = "postgres";
        public static string Password = "Salov_1999";
        public static string DatabaseName = "VkSpamerBase";
        public static string Host = "localhost";
        public static int Port = 5432;
    }
}
