using FluentValidation;
using LMS_ENTITIES.DTOs.Incoming.User;

namespace LMS_ENTITIES.Validators
{
    public class UserValidator : AbstractValidator<CreateUserDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("Please enter your name");

            RuleFor(u => u.Email).NotEmpty().WithMessage("Please enter your email address")
                .EmailAddress().WithMessage("Please enter a valid email address");

            RuleFor(u => u.Password).NotEmpty().WithMessage("Please provide a password")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters");

            RuleFor(u => u.PasswordConfirm).NotEmpty().WithMessage("Please confirm your password")
                .Equal(u => u.Password).WithMessage("Passwords doesn't match");

        }
    }
}
 