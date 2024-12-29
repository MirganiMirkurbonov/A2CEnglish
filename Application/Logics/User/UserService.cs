using Mapster;
using Database;
using Domain.Enums;
using Domain.Extensions;
using Domain.Models.API.User;
using Domain.Models.Response;
using Infrastructure.Interfaces;
using Infrastructure.Models.Token;
using Microsoft.EntityFrameworkCore;

namespace Application.Logics.User;

internal class UserService(EntityContext context, ITokenHandler tokenHandler) : IUser
{
    public async Task<DefaultResponse<TokenResult>> SignIn(SignInRequest request)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

        if (user == null)
            return new ErrorModel(ErrorEnum.UserNotFound);
        if (!PasswordExtension.VerifyPassword(request.Password, user.Password!))
            return new ErrorModel(ErrorEnum.InvalidPassword);

        var tokenModel = await tokenHandler.GenerateToken(user.Adapt<GenerateTokenModel>());
        return tokenModel.Adapt<TokenResult>();
    }

    public async Task<DefaultResponse<TokenResult>> SignUp(SignUpRequest request)
    {
        var isEmailUnique = await context.Users.AnyAsync(x => x.Email != request.Email);
        if (isEmailUnique == false)
            return new ErrorModel(ErrorEnum.UserAlreadyExists);

        var newUser = request.Adapt<Database.Tables.User>();

        await context.Users.AddAsync(newUser);
        await context.SaveChangesAsync();

        var tokenModel = await tokenHandler.GenerateToken(newUser.Adapt<GenerateTokenModel>());
        return tokenModel.Adapt<TokenResult>();
    }
}