using MediatR;
using TaskListServices.Application.Interface;
using TaskListServices.Dto;

namespace TaskListServices.Application.CQRS.Command.Update
{
    public class UpdateTaskListHandler : IRequestHandler<UpdateTaskListCommand, UpdateTaskListDto>
    {
        private readonly IUpdateTaskList _updateTaskList;
        public UpdateTaskListHandler(IUpdateTaskList updateTaskList)
        {
            _updateTaskList = updateTaskList;
        }
        public async Task<UpdateTaskListDto> Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
        {
            var Content = await _updateTaskList.Update(request.UpdateTaskListDto);
            if(Content != null)
            {
                return Content;
            }
            else
            {
              return Content = new UpdateTaskListDto{ Eror = "Ошибка" };
            }
        }
    }
}
