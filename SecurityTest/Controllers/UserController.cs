using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SecurityTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("User Controller");
        }
    }
}
