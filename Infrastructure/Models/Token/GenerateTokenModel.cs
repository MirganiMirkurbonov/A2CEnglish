namespace Infrastructure.Models.Token;

public record GenerateTokenModel(
    Guid UserId,
    string Name,
    string? Email,
    string? Phone);