using AutoMapper;
using MediatR;
using SecurityTest.Application.Common;
using SecurityTest.Application.Contract.Percistence;
using SecurityTest.Domain.Entities;

namespace SecurityTest.Application.Feactures.User.Queries.GetAllUser
{
    public class GetAllUsersQuery : IRequest<ApiResponse<List<UserDto>>>
    { 
    
    }
    public class GetAllUserQueryHandler(IAsyncRepository<Users> userRepository, IMapper mapper) : IRequestHandler<GetAllUsersQuery, ApiResponse<List<UserDto>>>
    {
        public async Task<ApiResponse<List<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
           var user = await Task.Run(()=> userRepository.GetByExpressionAsync(c=> c.IsActive).ToList());
           return new ApiResponse<List<UserDto>> { Message = null, Sucess = true, Result = mapper.Map<List<UserDto>>(user) };
        }
    }
}
