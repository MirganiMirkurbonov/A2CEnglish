namespace Infrastructure.Models.Token;

public record GenerateTokenModel(
    Guid UserId,
    string Name,
    string Role,
    string? Email,
    string? Phone);