using AutoMapper;
using MediatR;
using SecurityTest.Application.Common;
using SecurityTest.Application.Contract.Percistence;
using SecurityTest.Domain.Entities;

namespace SecurityTest.Application.Feactures.User.Command.CreateUser
{
    public class UpdateUserCommand : IRequest<ApiResponse<Users>>
    { 
    public int Id { get; set; }
     public string Email { get; set; }
     public string Name { get; set; }
     public string Role { get; set; } = "user";


    }
    public class UpdateUserCommandHandler(IAsyncRepository<Users> userRepository, IMapper _mapper) : IRequestHandler<UpdateUserCommand, ApiResponse<Users>>
    {
        public async Task<ApiResponse<Users>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await userRepository.GetByIdAsync(request.Id);
            if (entity is null)
            {
                return new ApiResponse<Users> { Message = "Usuario no encontrado", Sucess = false, Result = entity };
            }
            _mapper.Map(request, entity, typeof(UpdateUserCommand), typeof(Users));
            await userRepository.UpdateAsync(entity);
            return new ApiResponse<Users> { Message = "Usuario editado con exito", Sucess = true, Result = entity }; 
        }
    }
}
