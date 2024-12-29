namespace Domain.Models.API.User;

public record TokenResult(string Token, DateTime ExpireDate);