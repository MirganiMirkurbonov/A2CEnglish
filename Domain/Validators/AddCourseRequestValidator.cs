using Domain.Models.API.Course;
using FluentValidation;

namespace Domain.Validators;

public class AddCourseRequestValidator : AbstractValidator<AddCourseRequest>
{
    public AddCourseRequestValidator()
    {
        RuleFor(x => x.Title).NotNull().MaximumLength(100);
        RuleFor(x => x.Description).NotNull().MaximumLength(500).MinimumLength(30);
        RuleFor(x => x.EnglishLevel).NotNull();
    }
}