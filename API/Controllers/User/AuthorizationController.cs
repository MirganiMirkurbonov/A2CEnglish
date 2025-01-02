using API.Helpers;
using Application.Logics.User;
using Domain.Models.API.User;
using Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.User;

[ApiController]
[Route("api/[controller]/[action]")]
[ApiExplorerSettings(GroupName = "user")]

public class AuthorizationController(IUser user) : MainControllerBase<AuthorizationController>
{
    [HttpPost]
    public async Task<DefaultResponse<TokenResult>> SignIn(SignInRequest request)
        => await user.SignIn(request);

    [HttpPost]
    public async Task<DefaultResponse<TokenResult>> SignUp(SignUpRequest request)
        => await user.SignUp(request);
}