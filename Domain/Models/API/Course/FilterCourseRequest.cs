using Domain.Enums;

namespace Domain.Models.API.Course;

public record FilterCourseRequest(string? Title, EnglishLevel? EnglishLevel, bool? IsVisible, bool? MyAdded);