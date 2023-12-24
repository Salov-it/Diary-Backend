using MediatR;
using TaskListServices.Dto;

namespace TaskListServices.Application.CQRS.Command.Delete
{
    public class DeleteTaskListDtoCommand : IRequest<string>
    {
        public DeleteTaskListDto deleteTaskListDto { get; set; }
    }
}
