using Domain.Models.API.User;
using Domain.Models.Response;

namespace Application.Logics.User;

public interface IUser
{
    Task<DefaultResponse<TokenResult>> SignIn(SignInRequest request);
    Task<DefaultResponse<TokenResult>> SignUp(SignUpRequest request);
}