using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecurityTest.Application.Common;
using SecurityTest.Application.Feactures.User.Command.CreateUser;
using SecurityTest.Application.Feactures.User.Command.DeleteUser;
using SecurityTest.Application.Feactures.User.Queries.GetAllUser;
using SecurityTest.Application.Feactures.User.Queries.GetById;
using SecurityTest.Domain.Entities;

namespace SecurityTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Users>>> CreateUser(CreateUserCommand dto)=> Ok(await mediator.Send(dto));
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<Users>>> Update(int id, UpdateUserCommand dto)
        {
            if (id != dto.Id)
            {
                return new BadRequestObjectResult(new ApiResponse<Users> { Message = "El Id de la URL y del body deben ser el mismo", Sucess = false, Result = null });
            }
            return Ok(await mediator.Send(dto));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<Users>>> Delete(int id)=> Ok(await mediator.Send(new DeleteUserQuery { Id = id }));
        
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<UserDto>>>> GetAll()=> Ok(await mediator.Send(new GetAllUsersQuery()));
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<UserDto>>> Get(int id)=> Ok(await mediator.Send(new GetUserByIdQuery { Id=id}));
        
    }
}
