namespace Domain.Models.API.User;

public record SignInRequest(
    string Email,
    string Password);