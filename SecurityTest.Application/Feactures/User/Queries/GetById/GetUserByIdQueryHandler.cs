using AutoMapper;
using MediatR;
using SecurityTest.Application.Common;
using SecurityTest.Application.Contract.Percistence;
using SecurityTest.Application.Feactures.User.Queries.GetAllUser;
using SecurityTest.Domain.Entities;

namespace SecurityTest.Application.Feactures.User.Queries.GetById
{
    public class GetUserByIdQuery:IRequest<ApiResponse<UserDto>>
    {
        public int Id { get; set; }
    }
    public class GetUserByIdQueryHandler(IAsyncRepository<Users> userRepository, IMapper mapper) : IRequestHandler<GetUserByIdQuery, ApiResponse<UserDto>>
    {
        public async Task<ApiResponse<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await  userRepository.GetByIdAsync(request.Id);
            if (user is null)
            { 
            return new ApiResponse<UserDto> { Message = "User not found", Sucess = false, Result = null };

            }
            return new ApiResponse<UserDto> { Message = null, Sucess = true, Result = mapper.Map<UserDto>(user) };
        }
    }
}
