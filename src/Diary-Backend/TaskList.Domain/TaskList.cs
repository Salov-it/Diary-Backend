

namespace TaskListServices.Domain
{
    public class TaskList
    {

        public int id { get; set; }
        public string text { get; set; }
        public bool StatusTasks { get; set; }
        public DateTime Created { get; set; }
    }
}
