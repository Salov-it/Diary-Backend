using MediatR;
using TaskListServices.Dto;

namespace TaskListServices.Application.CQRS.Command.Create
{
    public class CreateTaskListCommand : IRequest<string>
    {
        public PostTaskListDto CreateTaskListDto { get; set; }
    }
}
