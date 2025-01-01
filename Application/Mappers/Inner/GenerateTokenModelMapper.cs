using Database.Tables;
using Infrastructure.Models.Token;
using Mapster;

namespace Application.Mappers.Inner;

public class GenerateTokenModelMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<User, GenerateTokenModel>()
            .ConstructUsing(src => Map(src));
    }

    private static GenerateTokenModel Map(User request)
    {
        return new GenerateTokenModel(
            UserId: request.Id,
            Role: request.Role.Keyword,
            Name: request.Name,
            Email: request.Email,
            Phone: request.Phone);
    }
}