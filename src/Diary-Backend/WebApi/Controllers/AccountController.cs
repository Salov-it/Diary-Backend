using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserDto.Dto;
using UserServices.Application.CQRS.Command.Authorization;
using UserServices.Application.CQRS.Command.UserRegistration;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;
        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost("AccountRegistration")]
        public async Task<IActionResult> AccountRegistration([FromBody] UserAddDto UserAdd)
        {
            var Content = new RegistrationCommand
            {
                UserAdd = UserAdd
            };
            var answer = await mediator.Send(Content);
            return Ok(answer);
        }

        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization([FromBody] UserLoginDto UserLoginDto)
        {
            var Content = new AuthorizationCommand
            {
                UserLoginDto = UserLoginDto
            };
            var answer = await mediator.Send(Content);
            return Ok(answer);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("User")]
        public async Task<IActionResult> User()
        {
           
            
            return Ok("Все четко");
        }

    }
}
