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
            .NewConfig<(SignUpRequest, Role), User>()
            .ConstructUsing(src => Map(src));
    }

    private static User Map((SignUpRequest, Role) src)
    {
        return new User
        {
            Email = src.Item1.Email,
            Password = src.Item1.Password.HashPassword(),
            Name = src.Item1.Name,
            Phone = src.Item1.Phone,
            Role = src.Item2,
            RoleId = src.Item2.Id,
            EnglishLevel = EnglishLevel.A1
        };
    }
}