using FluentValidation;

namespace TaskListServices.Application.CQRS.Command.Create
{
    public class CreateTaskListCommandValidation : AbstractValidator<CreateTaskListCommand>
    {
        public CreateTaskListCommandValidation() 
        {
            RuleFor(CreateTaskListCommand => CreateTaskListCommand.CreateTaskListDto.Login)
            .NotEmpty().WithMessage("Требуется Login.")
            .Length(3, 20).WithMessage("Login должен содержать от 3 до 20 символов.");

            RuleFor(CreateTaskListCommand => CreateTaskListCommand.CreateTaskListDto.Title)
           .NotEmpty().WithMessage("Требуется Title.")
           .Length(5, 50).WithMessage("Название должно содержать от 5 до 50 символов..");

            RuleFor(CreateTaskListCommand => CreateTaskListCommand.CreateTaskListDto.Text)
                .NotEmpty().WithMessage("Требуется Text.")
                .Length(10, 500).WithMessage("Текст должен содержать от 10 до 500 символов.");

            RuleFor(CreateTaskListCommand => CreateTaskListCommand.CreateTaskListDto.StatusTasks)
                .NotNull().WithMessage("Требуется StatusTasks.");

            RuleFor(CreateTaskListCommand => CreateTaskListCommand.CreateTaskListDto.Created)
                .NotNull().WithMessage("Требуется Created.")
                .LessThan(DateTime.Now).WithMessage("Дата создания не может быть в будущем.");
        }
    }

}
    

