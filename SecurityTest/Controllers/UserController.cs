using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecurityTest.Application.Common;
using SecurityTest.Application.Feactures.User.Command.CreateUser;
using SecurityTest.Application.Feactures.User.Command.DeleteUser;
using SecurityTest.Domain.Entities;

namespace SecurityTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Users>>> CreateUser(CreateUserCommand dto)
        {
            return Ok(await mediator.Send(dto));
        }
        [HttpDelete]
        public async Task<ActionResult<ApiResponse<Users>>> Delete(DeleteUserQuery dto)
        {
            return Ok(await mediator.Send(new DeleteUserQuery { Id=dto.Id}));
        }
    }
}
