

namespace TaskListServices.Dto
{
    public class GetAllTaskListDto
    {
        public int id { get; set; }
        public string NickName { get; set; }
        public string text { get; set; }
        public bool StatusTasks { get; set; }
        public DateTime Created { get; set; }
        public string Eror { get; set; }
       
    }
}
