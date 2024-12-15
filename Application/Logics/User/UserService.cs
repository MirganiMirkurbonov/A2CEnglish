using Domain.Models.API.User;
using Domain.Models.Response;
using Infrastructure.Models.Token;
using Mapster;

namespace Application.Logics.User;

internal class UserService : IUser
{
    public async Task<DefaultResponse<TokenResult>> SignIn(SignInRequest request)
    {
        var model = request.Adapt<GenerateTokenModel>();
        Console.WriteLine(model.Email);
        return new TokenResult();
    }

    public async Task<DefaultResponse<TokenResult>> SignUp(SignUpRequest request)
    {
        var model = request.Adapt<GenerateTokenModel>();
        Console.WriteLine(model.Email);
        return new TokenResult();
    }
}