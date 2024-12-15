namespace Infrastructure.Models.Token;

public record GenerateTokenModel(
    Guid Id,
    string Name,
    string? Email,
    string? Phone);