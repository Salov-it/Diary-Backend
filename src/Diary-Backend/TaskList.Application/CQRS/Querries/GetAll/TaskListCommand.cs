using MediatR;
using TaskListServices.Dto;


namespace TaskListServices.Application.CQRS.Command.GetAll
{
    public class TaskListCommand : IRequest<List<GetAllTaskListDto>>
    {
    }
}
