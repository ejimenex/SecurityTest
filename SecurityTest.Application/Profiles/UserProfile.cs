using AutoMapper;
using SecurityTest.Application.Feactures.User.Command.CreateUser;
using SecurityTest.Application.Feactures.User.Queries.GetAllUser;
using SecurityTest.Domain.Entities;
using System.Runtime.CompilerServices;

namespace SecurityTest.Application.Profiles
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserCommand,Users>();
            CreateMap<UpdateUserCommand, Users>();
            CreateMap<Users, UserDto>();
        }
        }
}
