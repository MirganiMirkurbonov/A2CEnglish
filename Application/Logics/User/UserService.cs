using Database;
using Domain.Enums;
using Domain.Extensions;
using Domain.Models.API.User;
using Domain.Models.Response;
using Infrastructure.Models.Token;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Logics.User;

internal class UserService(EntityContext context) : IUser
{
    public async Task<DefaultResponse<TokenResult>> SignIn(SignInRequest request)
    {
        var hasUser = await context.Users.FirstOrDefaultAsync(x=>x.Email == request.Email);
        
        if (hasUser == null)
            return new ErrorModel(ErrorEnum.UserNotFound);
        if (!PasswordExtension.VerifyPassword(request.Password, hasUser.Password!))
            return new ErrorModel(ErrorEnum.InvalidPassword);

        throw new NotImplementedException();
    }

    public async Task<DefaultResponse<TokenResult>> SignUp(SignUpRequest request)
    {
        var model = request.Adapt<GenerateTokenModel>();
        Console.WriteLine(model.Email);
        return new TokenResult();
    }
}