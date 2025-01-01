using Domain.Models.API.User;
using FluentValidation;

namespace Domain.Validators;

public class SignUpRequestValidator : AbstractValidator<SignUpRequest>
{
    public SignUpRequestValidator()
    {
        RuleFor(x => x.Email)
            .MinimumLength(7)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(50)
            .WithMessage("Email is required");

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);
    }
}