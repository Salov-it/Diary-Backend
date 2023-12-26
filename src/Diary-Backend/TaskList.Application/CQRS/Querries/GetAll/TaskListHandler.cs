using MediatR;
using TaskListServices.Application.CQRS.Command.Update;
using TaskListServices.Application.CQRS.Querries.GetAll;
using TaskListServices.Application.Interface;
using TaskListServices.Dto;

namespace TaskListServices.Application.CQRS.Command.GetAll
{
    public class TaskListHandler : IRequestHandler<TaskListCommand, List<GetAllTaskListDto>>
    {
        private readonly IGetTaskList _getTaskList;

        List<GetAllTaskListDto> Eror = new List<GetAllTaskListDto>();

        public TaskListHandler(IGetTaskList getTaskList)
        {
            _getTaskList = getTaskList;
        }
        public async Task<List<GetAllTaskListDto>> Handle(TaskListCommand request, CancellationToken cancellationToken)
        {
            
            var Validation = new TaskListCommandValidation();
            var validationResult = Validation.Validate(request);
            if (!validationResult.IsValid)
            {
                GetAllTaskListDto Status = new GetAllTaskListDto();
                foreach (var error in validationResult.Errors)
                {
                    Status.Eror = error.ErrorMessage;
                    Eror.Add(Status);
                    return Eror;
                }
            }

            var Content = await _getTaskList.GetAll(request.GetTaskListDto);
            if(Content != null)
            {
                return Content;
            }
            else
            {
                GetAllTaskListDto Status = new GetAllTaskListDto { Eror = "Ошибка" };
                Eror.Add(Status);
                return Eror;
            }
          
        }
    }
}
