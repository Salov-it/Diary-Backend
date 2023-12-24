

namespace TaskListServices.Dto
{
    public class PostTaskListDto
    {
        public string NickName { get; set; }
        public string text { get; set; }
        public bool StatusTasks { get; set; }
        public DateTime Created { get; set; }
    }
}
