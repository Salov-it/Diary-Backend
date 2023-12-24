

namespace DatabasePostgres.Persistance.SqlRequest.TaskListSqlRequest
{
    public class TaskListSqlRequest
    {
        public string CreateTasksTable = "CREATE TABLE Tasks (id SERIAL PRIMARY KEY,NickName TEXT,texts TEXT,StatusTasks BOOLEAN, Created DATE);";

        public string Add = $"INSERT INTO tasks (NickName,texts,StatusTasks,Created)" +
            "VALUES ($1,$2,$3,$4);";

        public string GetTasksInfo = "SELECT * FROM Tasks;";

        public string Delete = "DELETE FROM tasks WHERE id = $1;";

        public string Update = "UPDATE Tasks SET texts = $2,statustasks = $3 WHERE id = $1 RETURNING *;";
    }
}
