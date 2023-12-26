using MediatR;
using TaskListServices.Dto;

namespace TaskListServices.Application.CQRS.Command.Update
{
    public class UpdateTaskListCommand : IRequest<string>
    {
        public UpdateTaskListDto UpdateTaskListDto { get; set; }    
    }
}
