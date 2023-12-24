using DatabasePostgres.Persistance.Interface;
using TaskListServices.Application.Interface;
using TaskListServices.Dto;

namespace TaskListServices.Application.CQRS.Command.GetAll
{
    public class GetTaskList : IGetTaskList
    {
        private readonly ITaskListRepositoryPostgres _taskListRepositoryPostgres;
        public List<GetAllTaskListDto> Result = new List<GetAllTaskListDto>();
        public GetTaskList(ITaskListRepositoryPostgres taskListRepositoryPostgres)
        {
            _taskListRepositoryPostgres = taskListRepositoryPostgres;
        }

        public async Task<List<GetAllTaskListDto>> GetAll()
        {
            var Content = await _taskListRepositoryPostgres.GetAll();
            if(Content.Count > 0) 
            {
                return Content;
            }
            else
            {
                GetAllTaskListDto content = new GetAllTaskListDto() { Eror = "Список задач пуст" };
                Result.Add(content);
                return Result;
            }
        }

    }
}
