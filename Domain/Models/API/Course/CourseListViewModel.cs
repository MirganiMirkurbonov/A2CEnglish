using Domain.Enums;

namespace Domain.Models.API.Course;

public record CourseListViewModel(
    Guid Id,
    string Title,
    string Description,
    string? PhotoPath,
    bool IsVisible,
    DateTime CreatedDate,
    EnglishLevel EnglishLevel);