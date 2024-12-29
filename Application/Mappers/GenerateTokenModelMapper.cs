using Database.Tables;
using Domain.Models.API.User;
using Infrastructure.Models.Token;
using Mapster;

namespace Application.Mappers;

public class GenerateTokenModelMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<SignUpRequest, GenerateTokenModel>()
            .ConstructUsing(src => Map(src));
        
        config
            .NewConfig<User, GenerateTokenModel>()
            .ConstructUsing(src => Map(src));
    }

    private static GenerateTokenModel Map(User request)
    {
        return new GenerateTokenModel(
            UserId: request.Id,
            Name: request.Name,
            Email: request.Email,
            Phone: request.Phone);
    }

    private static GenerateTokenModel Map(SignUpRequest request)
    {
        return new GenerateTokenModel(
            UserId: Guid.NewGuid(),
            Name: request.Name,
            Email: request.Email,
            Phone: request.Phone);
    }
}