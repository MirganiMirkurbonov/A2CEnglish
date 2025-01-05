using Domain.Models.API.User;
using Domain.Models.Response;

namespace Application.Logics.User;

public interface IUser
{
    Task<DefaultResponse<TokenResult>> SignInAsync(SignInRequest request);
    Task<DefaultResponse<TokenResult>> SignUpAsync(SignUpRequest request);
}