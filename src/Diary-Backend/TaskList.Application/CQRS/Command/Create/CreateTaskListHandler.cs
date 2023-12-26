using MediatR;
using TaskListServices.Application.Interface;

namespace TaskListServices.Application.CQRS.Command.Create
{
    public class CreateTaskListHandler : IRequestHandler<CreateTaskListCommand, string>
    {
        private readonly ICreateTaskList _createTaskList;
        public string Result { get; set; }
        public CreateTaskListHandler(ICreateTaskList createTaskList)
        {
            _createTaskList = createTaskList;   
        }
        public async Task<string> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
        {
            var Validation = new CreateTaskListCommandValidation();
            var validationResult = Validation.Validate(request);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    return error.ErrorMessage;
                }
            }

            var Content = await _createTaskList.Create(request.CreateTaskListDto);

            if (Content != null) 
            {
                Result = "Выполнено";
            }
            else
            {
                Result = "Ошибка";
            }
            return Result;
        }
    }
}
