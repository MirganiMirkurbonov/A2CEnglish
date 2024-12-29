namespace Domain.Models.Options;

public record JwtTokenOptions(
    string Secret,
    string Issuer,
    string Audience,
    int ExpirationMinutes)
{
    public JwtTokenOptions() : this(default, default, default, default)
    {
        
    }
};