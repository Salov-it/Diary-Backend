using FluentValidation;
using TaskListServices.Application.CQRS.Command.GetAll;


namespace TaskListServices.Application.CQRS.Querries.GetAll
{
    public class TaskListCommandValidation : AbstractValidator<TaskListCommand>
    {
        public TaskListCommandValidation() 
        {
            RuleFor(TaskListCommand => TaskListCommand.GetTaskListDto.Login)
            .NotEmpty().WithMessage("Требуется Login.")
            .Length(3, 20).WithMessage("Login должен содержать от 3 до 20 символов.");
        }
    }
}
