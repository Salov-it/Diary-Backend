using TaskListServices.Dto;

namespace DatabasePostgres.Persistance.Interface
{
    public interface ITaskListRepositoryPostgres
    {
        Task<string> CreateTable();
        Task<string> Add(PostTaskListDto taskListDto);
        Task<List<GetAllTaskListDto>> GetAll();
        Task<UpdateTaskListDto> Update(UpdateTaskListDto updateTaskListDto);
        Task<string> Delete(DeleteTaskListDto deleteTaskListDto);

    }
}
