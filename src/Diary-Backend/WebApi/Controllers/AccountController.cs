using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserServices.Application.CQRS.Command.Authorization;
using UserServices.Application.CQRS.Command.UserRegistration;
using UserServices.Application.Dto;

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
        public async Task<IActionResult> AccountRegistration([FromBody] RegistrationResponseDto registration)
        {
            var Content = new RegistrationCommand
            {
                registrationDto = registration
            };
            var answer = await mediator.Send(Content);
            return Ok(answer);
        }

        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization([FromBody] UserInfoDto userInfo)
        {
            var Content = new AuthorizationCommand
            {
                UserInfo = userInfo
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
