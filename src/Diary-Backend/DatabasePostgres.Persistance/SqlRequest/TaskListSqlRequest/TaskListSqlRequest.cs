

namespace DatabasePostgres.Persistance.SqlRequest.TaskListSqlRequest
{
    public class TaskListSqlRequest
    {
        public string CreateTasksTable = "CREATE TABLE tasks (id SERIAL PRIMARY KEY,Login TEXT,texts TEXT,StatusTasks BOOLEAN, Created DATE);";

        public string Add = $"INSERT INTO tasks (Login,texts,StatusTasks,Created)" +
            "VALUES ($1,$2,$3,$4);";

        public string GetTasksInfo = "SELECT * FROM tasks WHERE login = $1;";

        public string Delete = "DELETE FROM tasks WHERE id = $1;";

        public string Update = "UPDATE Tasks SET texts = $2,statustasks = $3 WHERE id = $1 RETURNING *;";
    }
}
