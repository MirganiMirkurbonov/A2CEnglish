namespace Domain.Models.API.User;

public record SignUpRequest(
    string Name,
    string Email,
    string Phone,
    string Password);