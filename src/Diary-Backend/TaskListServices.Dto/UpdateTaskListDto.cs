

namespace TaskListServices.Dto
{
    public class UpdateTaskListDto
    {
        public int id {  get; set; }
        public string text { get; set; }
        public bool StatusTasks { get; set; }
        public string Eror { get; set; }
    }
}
