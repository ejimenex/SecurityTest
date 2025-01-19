using FluentValidation;
using SecurityTest.Application.Contract.Percistence;
using SecurityTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityTest.Application.Feactures.User.Command.CreateUser
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserCommand>
    {
        private readonly IAsyncRepository<Users> _userRepository;
        public UpdateUserValidation(IAsyncRepository<Users> userRespository)
        {
            _userRepository = userRespository;
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name it is Required.")
                .MinimumLength(3).WithMessage("The name must have unless 3 characters");

            RuleFor(p => p.Email).NotEmpty().WithMessage("Email it is Required.");

            RuleFor(p => p.UserName).NotEmpty().WithMessage("UserName it is Required.");

            RuleFor(p => p.Email).EmailAddress().WithMessage("Invalid Email Format");

            RuleFor(p=> p.Role).Must(p => p.Equals("admin") || p.Equals("user")).WithMessage("The role must be Admin or User");
            RuleFor(c => c).MustAsync(ValidateEmailExist).WithMessage("This email already exist in other record");



        }
         private async Task<bool> ValidateEmailExist(UpdateUserCommand e, CancellationToken token) => (!await _userRepository.ExistAsync(c=> c.Email.Equals(e.Email) && c.Id != e.Id && c.IsActive));
    }
}
