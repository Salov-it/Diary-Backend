using MediatR;
using TaskListServices.Dto;

namespace TaskListServices.Application.CQRS.Command.Update
{
    public class UpdateTaskListCommand : IRequest<UpdateTaskListDto>
    {
        public UpdateTaskListDto UpdateTaskListDto { get; set; }
    }
}
