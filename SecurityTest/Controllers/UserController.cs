using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecurityTest.Application.Common;
using SecurityTest.Application.Feactures.User.Command.CreateUser;
using SecurityTest.Application.Feactures.User.Command.DeleteUser;
using SecurityTest.Application.Feactures.User.Queries.GetAllUser;
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
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ApiResponse<Users>>> Update([FromRoute] int id,UpdateUserCommand dto)
        {
            if (id != dto.Id)
            { 
            return new BadRequestObjectResult(new ApiResponse<Users> { Message = "The id in the route and the id in the body must be the same", Sucess = false, Result = null });
            }
            return Ok(await mediator.Send(dto));
        }
        [HttpDelete]
        public async Task<ActionResult<ApiResponse<Users>>> Delete(DeleteUserQuery dto)
        {
            return Ok(await mediator.Send(new DeleteUserQuery { Id=dto.Id}));
        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<UserDto>>>> GetAll()
        {
            return Ok(await mediator.Send(new GetAllUsersQuery()));
        }
    }
}
