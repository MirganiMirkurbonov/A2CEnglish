namespace Infrastructure.Models.Token;

public record GenerateTokenResult(
    string AccessToken,
    DateTime ExpireDate);