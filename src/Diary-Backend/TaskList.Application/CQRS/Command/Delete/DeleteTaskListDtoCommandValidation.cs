using FluentValidation;


namespace TaskListServices.Application.CQRS.Command.Delete
{
    public class DeleteTaskListDtoCommandValidation : AbstractValidator<DeleteTaskListDtoCommand>
    {
        public DeleteTaskListDtoCommandValidation()
        {
            RuleFor(DeleteTaskListDtoCommand => DeleteTaskListDtoCommand.deleteTaskListDto.id)
             .GreaterThan(0).WithMessage("id должен быть больше 0.");
        }
    } 
}
