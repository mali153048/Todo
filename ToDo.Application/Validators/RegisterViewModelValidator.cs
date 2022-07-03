using FluentValidation;
using ToDo.Application.Contracts.Repositories;
using ToDo.Application.DTO;

namespace ToDo.Application.Validators
{
    public class RegisterViewModelValidator : AbstractValidator<RegisterDTO>
    {
        private readonly IUserRepository _userRepository;
        public RegisterViewModelValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(p => p.Username)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(async (username, cancellation) =>
                {
                    return !(await UsernameExists(username, cancellation));
                }).WithMessage("Username is taken. Please try another one"); ;

            RuleFor(p => p.Password)
                .Equal(cp => cp.ConfirmPassword).WithMessage("Password and ConfirmPassword do not match.")
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.ConfirmPassword)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }

        private async Task<bool> UsernameExists(string username, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            if (user == null)
                return false;

            return true;
        }
    }
}
