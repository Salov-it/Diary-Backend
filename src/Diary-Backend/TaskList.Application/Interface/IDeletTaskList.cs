using TaskListServices.Dto;

namespace TaskListServices.Application.Interface
{
    public interface IDeletTaskList
    {
        Task<string> Delete(DeleteTaskListDto deleteTaskListDto);
    }
}
