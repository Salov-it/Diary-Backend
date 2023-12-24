using DatabasePostgres.Persistance.Interface;
using TaskListServices.Application.Interface;
using TaskListServices.Dto;

namespace TaskListServices.Application.CQRS.Command.Upgate
{
    public class UpdateTaskList : IUpdateTaskList
    {
        private readonly ITaskListRepositoryPostgres _taskListRepositoryPostgres;
        public UpdateTaskList(ITaskListRepositoryPostgres taskListRepositoryPostgres)
        {
            _taskListRepositoryPostgres = taskListRepositoryPostgres;
        }
        public async Task<UpdateTaskListDto> Update(UpdateTaskListDto updateTaskListDto)
        {
           return await _taskListRepositoryPostgres.Update(updateTaskListDto);
        }

    }
}
