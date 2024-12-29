using Database.Enums;
using Database.Tables;
using Domain.Extensions;
using Domain.Models.API.User;
using Mapster;

namespace Application.Mappers;

public class UserMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<SignUpRequest, User>()
            .ConstructUsing(src => Map(src));
    }

    private static User Map(SignUpRequest src)
    {
        return new User
        {
            Email = src.Email,
            Password = src.Password.HashPassword(),
            Name = src.Name,
            Phone = src.Phone,
            EnglishLevel = EnglishLevel.A1
        };
    }
}