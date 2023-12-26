

namespace TaskListServices.Dto
{
    public class GetAllTaskListDto
    {
        public int id { get; set; }
        public string Login { get; set; }
        public string Text { get; set; }
        public bool StatusTasks { get; set; }
        public DateTime Created { get; set; }
        public string Eror { get; set; }
       
    }
}
