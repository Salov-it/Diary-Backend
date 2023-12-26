using DatabasePostgres.Persistance.Interface;
using System.Security.Claims;
using TaskListServices.Application.Interface;
using TaskListServices.Dto;
using System.Security.Claims;
using System.Net.Http;

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

        public async Task<List<GetAllTaskListDto>> GetAll(GetTaskListLoginDto getTaskListLoginDto)
        {
            var Content = await _taskListRepositoryPostgres.GetAll(getTaskListLoginDto);
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
