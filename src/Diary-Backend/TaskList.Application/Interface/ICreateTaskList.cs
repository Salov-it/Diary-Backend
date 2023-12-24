using TaskListServices.Dto;

namespace TaskListServices.Application.Interface
{
    public interface ICreateTaskList
    {
        Task<string> Create(PostTaskListDto taskListDto);
    }
}
