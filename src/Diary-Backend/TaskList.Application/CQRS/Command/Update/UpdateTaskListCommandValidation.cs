using FluentValidation;

namespace TaskListServices.Application.CQRS.Command.Update
{
    public class UpdateTaskListCommandValidation : AbstractValidator<UpdateTaskListCommand>
    {
        public UpdateTaskListCommandValidation() 
        {
            RuleFor(updateTaskListCommand => updateTaskListCommand.UpdateTaskListDto.id)
            .GreaterThan(0).WithMessage("Id должен быть больше 0.");

            RuleFor(updateTaskListCommand => updateTaskListCommand.UpdateTaskListDto.Title)
           .NotEmpty().WithMessage("Требуется Title.")
           .Length(5, 50).WithMessage("Название должно содержать от 5 до 50 символов..");

            RuleFor(updateTaskListCommand => updateTaskListCommand.UpdateTaskListDto.Text)
                .NotEmpty().WithMessage("Требуется Text.")
                .Length(10, 500).WithMessage("Текст должен содержать от 10 до 500 символов.");

            RuleFor(updateTaskListCommand => updateTaskListCommand.UpdateTaskListDto.StatusTasks)
                .NotNull().WithMessage("Требуется StatusTasks.");

        }

    }
}
