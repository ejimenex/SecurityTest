using AutoMapper;
using MediatR;
using SecurityTest.Application.Contract.Percistence;
using SecurityTest.Domain.Entities;

namespace SecurityTest.Application.Feactures.User.Command.CreateUser
{
    public class CreateUserCommand : IRequest<Users>
    { 
     public string Email { get; set; }
     public string UserName { get; set; }
     public string Name { get; set; }
     public string Role { get; set; } = "user";


    }
    public class CreateUserCommandHandler(IAsyncRepository<Users> userRepository, IMapper _mapper) : IRequestHandler<CreateUserCommand, Users>
    {
        public async Task<Users> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Users>(request);
            return await userRepository.AddAsync(user);
        }
    }
}
