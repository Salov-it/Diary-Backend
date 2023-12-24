using TaskListServices.Dto;

namespace TaskListServices.Application.Interface
{
    public interface IUpdateTaskList
    {
        Task<UpdateTaskListDto> Update(UpdateTaskListDto updateTaskListDto);
    }
}
