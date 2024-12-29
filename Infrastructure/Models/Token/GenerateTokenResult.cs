namespace Infrastructure.Models.Token;

public record GenerateTokenResult(
    string Token,
    DateTime ExpireDate);