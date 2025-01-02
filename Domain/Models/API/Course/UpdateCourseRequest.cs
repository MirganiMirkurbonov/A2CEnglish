using Domain.Enums;

namespace Domain.Models.API.Course;

public record UpdateCourseRequest(
    Guid Id,
    string Title,
    string Description,
    EnglishLevel EnglishLevel);