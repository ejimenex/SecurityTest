using MediatR;
using SecurityTest.Application.Common;
using SecurityTest.Application.Contract.Percistence;
using SecurityTest.Domain.Entities;

namespace SecurityTest.Application.Feactures.User.Command.DeleteUser
{
    public class DeleteUserQuery : IRequest<ApiResponse<Users>> { 
    public int Id { get; set; }
    }
    public class DeleteUserQueryHandler(IAsyncRepository<Users> userRepository) : IRequestHandler<DeleteUserQuery, ApiResponse<Users>>
    {
        public async Task<ApiResponse<Users>> Handle(DeleteUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                return new ApiResponse<Users> { Message= $"Usuario con Id {request.Id} no encontrado.", Sucess=false,Result=null};
            }
            user.IsActive = false;
            await userRepository.UpdateAsync(user);
            return new ApiResponse<Users> { Message = $"Usuario con Id {request.Id} ha sido borrado.", Sucess = true, Result = user };

        }
    }
}
