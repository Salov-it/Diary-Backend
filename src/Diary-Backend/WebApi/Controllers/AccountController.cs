using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] string value)
        {
            return Ok("ok");
        }

       

       
    }
}
