using MediatR;
using TaskListServices.Application.Interface;

namespace TaskListServices.Application.CQRS.Command.Delete
{
    public class DeleteTaskListDtoHandler : IRequestHandler<DeleteTaskListDtoCommand, string>
    {
        private readonly IDeletTaskList _deletTaskList;
        public DeleteTaskListDtoHandler(IDeletTaskList deletTaskList)
        {
            _deletTaskList = deletTaskList;
        }
        public async Task<string> Handle(DeleteTaskListDtoCommand request, CancellationToken cancellationToken)
        {
            var Content = await _deletTaskList.Delete(request.deleteTaskListDto);
            if(Content != null)
            {
                return "200";
            }
            else
            {
                return "Ошибка удаления";
            }
        }
    }
}
