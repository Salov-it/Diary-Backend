

namespace TaskListServices.Dto
{
    public class UpdateTaskListDto
    {
        public int id {  get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool StatusTasks { get; set; }
        public string Eror { get; set; }
    }
}
