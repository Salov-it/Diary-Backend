using DatabasePostgres.Persistance.Interface;
using TaskListServices.Application.Interface;
using TaskListServices.Dto;

namespace TaskListServices.Application.CQRS.Command.Create
{
    public class CreateTaskList : ICreateTaskList
    {
        private readonly ITaskListRepositoryPostgres _TaskListRepositoryPostgres;
        public CreateTaskList(ITaskListRepositoryPostgres taskListRepositoryPostgres)
        {
            _TaskListRepositoryPostgres = taskListRepositoryPostgres;
        }
        public async Task<string> Create(PostTaskListDto taskListDto)
        {
          return  await _TaskListRepositoryPostgres.Add(taskListDto);
        }

    }
}
