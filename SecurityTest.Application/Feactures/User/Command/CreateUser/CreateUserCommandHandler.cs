using AutoMapper;
using MediatR;
using SecurityTest.Application.Common;
using SecurityTest.Application.Contract.Percistence;
using SecurityTest.Domain.Entities;
using System.Text.RegularExpressions;

namespace SecurityTest.Application.Feactures.User.Command.CreateUser
{
    public class CreateUserCommand : IRequest<ApiResponse<Users>>
    { 
     public string Email { get; set; }
     public string Name { get; set; }
     public string Role { get; set; } = "user";


    }
    public class CreateUserCommandHandler(IAsyncRepository<Users> userRepository, IMapper _mapper) : IRequestHandler<CreateUserCommand, ApiResponse<Users>>
    {
        public async Task<ApiResponse<Users>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            Users user = _mapper.Map<Users>(request);
            user.UserName = Regex.Replace(request.Email, @"@.*", "");
            await userRepository.AddAsync(user);
            return new ApiResponse<Users> { Message = "Usuario insertado exitosamente", Sucess = true, Result = user }; 
        }
    }
}
