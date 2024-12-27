using Infrastructure.Models.Token;

namespace Infrastructure.Interfaces;

public interface ITokenHandler
{
    Task<GenerateTokenResult> GenerateToken(GenerateTokenModel model);
}