using MediatR;
using TaskListServices.Application.Interface;
using TaskListServices.Dto;

namespace TaskListServices.Application.CQRS.Command.GetAll
{
    public class TaskListHandler : IRequestHandler<TaskListCommand, List<GetAllTaskListDto>>
    {
        private readonly IGetTaskList _getTaskList;
        public TaskListHandler(IGetTaskList getTaskList)
        {
            _getTaskList = getTaskList;
        }
        public async Task<List<GetAllTaskListDto>> Handle(TaskListCommand request, CancellationToken cancellationToken)
        {
           return await _getTaskList.GetAll(); 
        }
    }
}
