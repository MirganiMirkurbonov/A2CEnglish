using Domain.Models.API.Course;
using FluentValidation;

namespace Domain.Validators;

public class UpdateCourseRequestValidator : AbstractValidator<UpdateCourseRequest>
{
    public UpdateCourseRequestValidator()
    {
        RuleFor(x => x.Title).NotNull().MaximumLength(100);
        RuleFor(x => x.Description).NotNull().MaximumLength(500).MinimumLength(30);
        RuleFor(x => x.EnglishLevel).NotNull();
    }
}