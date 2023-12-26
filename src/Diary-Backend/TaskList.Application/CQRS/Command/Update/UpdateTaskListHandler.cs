using MediatR;
using TaskListServices.Application.Interface;

namespace TaskListServices.Application.CQRS.Command.Update
{
    public class UpdateTaskListHandler : IRequestHandler<UpdateTaskListCommand, string>
    {
        private readonly IUpdateTaskList _updateTaskList;
        public UpdateTaskListHandler(IUpdateTaskList updateTaskList)
        {
            _updateTaskList = updateTaskList;
        }
        public async Task<string> Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
        {
            var Validation = new UpdateTaskListCommandValidation();
            var validationResult = Validation.Validate(request);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    return error.ErrorMessage;
                }
            }
            var Content = await _updateTaskList.Update(request.UpdateTaskListDto);
            if(Content != null)
            {
                return "Выполнено";
            }
            else
            {
              return "Ошибка";
            }
        }
    }
}
