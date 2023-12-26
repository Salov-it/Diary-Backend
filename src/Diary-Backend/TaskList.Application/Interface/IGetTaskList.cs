using TaskListServices.Dto;

namespace TaskListServices.Application.Interface
{
    public interface IGetTaskList
    {
        Task<List<GetAllTaskListDto>> GetAll(GetTaskListLoginDto getTaskListLoginDto);
    }
}
