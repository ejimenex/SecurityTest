using AutoMapper;
using MediatR;
using SecurityTest.Application.Common;
using SecurityTest.Application.Contract.Percistence;
using SecurityTest.Domain.Entities;

namespace SecurityTest.Application.Feactures.User.Command.CreateUser
{
    public class CreateUserCommand : IRequest<ApiResponse<Users>>
    { 
     public string Email { get; set; }
     public string UserName { get; set; }
     public string Name { get; set; }
     public string Role { get; set; } = "user";


    }
    public class CreateUserCommandHandler(IAsyncRepository<Users> userRepository, IMapper _mapper) : IRequestHandler<CreateUserCommand, ApiResponse<Users>>
    {
        public async Task<ApiResponse<Users>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
           var user=  await userRepository.AddAsync(_mapper.Map<Users>(request));
            return new ApiResponse<Users> { Message = "User added sucessfully", Sucess = true, Result = user }; 
        }
    }
}
