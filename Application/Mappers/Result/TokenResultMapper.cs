using Domain.Models.API.User;
using Infrastructure.Models.Token;
using Mapster;

namespace Application.Mappers.Result;

public class TokenResultMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<GenerateTokenResult, TokenResult>()
            .ConstructUsing(src => Map(src));
    }

    private static TokenResult Map(GenerateTokenResult src)
    {
        return new TokenResult(
            Token: src.Token,
            ExpireDate: src.ExpireDate);
    }
}