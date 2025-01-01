using System.Security.Claims;
using System.Text;
using Domain.Models.Options;
using Infrastructure.Interfaces;
using Infrastructure.Models.Token;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace Infrastructure.Handlers;

internal class TokenHandler(IOptions<JwtTokenOptions> options) : ITokenHandler
{
    public async Task<GenerateTokenResult> GenerateToken(GenerateTokenModel model)
    {
        var expiration = DateTime.UtcNow.AddMinutes(options.Value.ExpirationMinutes);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Secret));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, model.UserId.ToString()),
            new(JwtRegisteredClaimNames.Name, model.Name),
            new(JwtRegisteredClaimNames.Email, model.Email ?? string.Empty),
            new(JwtRegisteredClaimNames.PhoneNumber, model.Phone ?? string.Empty),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new ("role", model.Role)
        };

        var tokenDescriptor = new JwtSecurityToken(
            issuer: options.Value.Issuer,
            audience: options.Value.Audience,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.WriteToken(tokenDescriptor);

        return await Task.FromResult(new GenerateTokenResult(token, expiration));
    }
}