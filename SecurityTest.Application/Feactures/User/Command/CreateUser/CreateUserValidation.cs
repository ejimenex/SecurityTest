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
    public class CreateUserValidation : AbstractValidator<CreateUserCommand>
    {
        private readonly IAsyncRepository<Users> _userRepository;
        public CreateUserValidation(IAsyncRepository<Users> userRespository)
        {
            _userRepository = userRespository;
            RuleFor(p => p.Name).NotEmpty().WithMessage("Nombre es obligatorio.")
                .MinimumLength(3).WithMessage("El Nombre debe tener al menos 3 caracteres");

            RuleFor(p => p.Email).NotEmpty().WithMessage("Email es obligatorio.");

            RuleFor(p => p.Email).EmailAddress().WithMessage("Formato de email invalido");

            RuleFor(p=> p.Role).Must(p => p.Equals("admin") || p.Equals("user")).WithMessage("El rol debe ser 'Admin' ó 'User'");
            RuleFor(c => c).MustAsync(ValidateEmailExist).WithMessage("Ya hay un registro con este Email.");



        }
         private async Task<bool> ValidateEmailExist(CreateUserCommand e, CancellationToken token) => (!await _userRepository.ExistAsync(c=> c.Email.Equals(e.Email) && c.IsActive));
    }
}
