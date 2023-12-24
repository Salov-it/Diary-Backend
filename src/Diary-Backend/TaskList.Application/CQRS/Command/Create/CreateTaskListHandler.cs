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
            var Content = await _createTaskList.Create(request.CreateTaskListDto);
            if(Content != null) 
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
