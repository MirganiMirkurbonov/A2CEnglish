using Domain.Enums;

namespace Domain.Models.API.Course;

public record AddCourseRequest(
    string Title,
    string Description,
    EnglishLevel EnglishLevel);