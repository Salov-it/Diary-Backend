using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskListServices.Application.CQRS.Command.Create;
using TaskListServices.Application.CQRS.Command.Delete;
using TaskListServices.Application.CQRS.Command.GetAll;
using TaskListServices.Application.CQRS.Command.Update;
using TaskListServices.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "User")]
    public class TaskListServicesController : ControllerBase
    {
        private readonly IMediator mediator;
        public TaskListServicesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PostTaskListDto taskListDto)
        {
            var Content = new CreateTaskListCommand
            {
                CreateTaskListDto = taskListDto,
            };
            var answer = await mediator.Send(Content);
            return Ok(answer);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateTaskListDto updateTaskListDto)
        {
            var Content = new UpdateTaskListCommand
            {
               UpdateTaskListDto = updateTaskListDto
            };
            var answer = await mediator.Send(Content);
            return Ok(answer);
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromBody] GetTaskListLoginDto getTaskListLogin)
        {
            var Content = new TaskListCommand
            {
                GetTaskListDto = getTaskListLogin
            };
            var answer = await mediator.Send(Content);
            return Ok(answer);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteTaskListDto deleteTaskListDto )
        {
            var Content = new DeleteTaskListDtoCommand
            {
                deleteTaskListDto = deleteTaskListDto
            };
            var answer = await mediator.Send(Content);
            return Ok(answer);
        }
    }
}
