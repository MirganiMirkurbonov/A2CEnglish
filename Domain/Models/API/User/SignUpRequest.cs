using Domain.Enums;

namespace Domain.Models.API.User;

public record SignUpRequest(
    string Name,
    string Email,
    string Phone,
    string Password,
    EnglishLevel EnglishLevel);