using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecurityTest.Application.Feactures.User.Command.CreateUser;
using SecurityTest.Domain.Entities;
using System.Data;

namespace SecurityTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Users>> CreateUser(CreateUserCommand dto)
        {
            return Ok(await mediator.Send(dto));
        }
    }
}
