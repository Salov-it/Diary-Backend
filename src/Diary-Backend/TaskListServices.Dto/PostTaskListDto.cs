

namespace TaskListServices.Dto
{
    public class PostTaskListDto
    {
        public string Login { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool StatusTasks { get; set; }
        public DateTime Created { get; set; }
    }
}
