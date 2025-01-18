using AutoMapper;
using SecurityTest.Application.Feactures.User.Command.CreateUser;
using SecurityTest.Domain.Entities;

namespace SecurityTest.Application.Profiles
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<Users, CreateUserCommand>().ReverseMap();
        }
        }
}
