using DatabasePostgres.Persistance.Dto.TaskListDto;
using DatabasePostgres.Persistance.Interface;
using TaskListServices.Application.Interface;

namespace TaskListServices.Application.CQRS.Command.Delete
{
    public class DeletTaskList : IDeletTaskList
    {
        private readonly ITaskListRepositoryPostgres _taskListRepositoryPostgres;
        public DeletTaskList(ITaskListRepositoryPostgres taskListRepositoryPostgres)
        {
            _taskListRepositoryPostgres = taskListRepositoryPostgres;
        }
        public async Task<string> Delete(DeleteTaskListDto deleteTaskListDto)
        {
            return await _taskListRepositoryPostgres.Delete(deleteTaskListDto);
        }
    }
}
