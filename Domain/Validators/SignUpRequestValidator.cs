using Domain.Models.API.User;
using FluentValidation;

namespace Domain.Validators;

public class SignUpRequestValidator : AbstractValidator<SignUpRequest>
{
    public SignUpRequestValidator()
    {
        RuleFor(x => x.Email)
            .MinimumLength(10)
            .NotEmpty()
            .WithMessage("Email is required");
    }
}