using FluentValidation;
using ToDo.Application.DTO;

namespace ToDo.Application.Validators
{
    public class LoginViewModelValidator: AbstractValidator<LoginDTO>
    {
        public LoginViewModelValidator()
        {
            RuleFor(p => p.Username)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
