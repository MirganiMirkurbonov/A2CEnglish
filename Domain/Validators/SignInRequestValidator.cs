using Domain.Models.API.User;
using FluentValidation;

namespace Domain.Validators;

public class SignInRequestValidator : AbstractValidator<SignInRequest>
{
    public SignInRequestValidator()
    {
        RuleFor(x => x.Email).EmailAddress().MaximumLength(70);
        RuleFor(x => x.Password).MinimumLength(5).MaximumLength(50);
    }
}