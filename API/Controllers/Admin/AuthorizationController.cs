using API.Helpers;
using Application.Logics.User;
using Domain.Models.API.User;
using Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Admin;

[ApiController]
[Route("api-admin/[controller]/[action]")]
[ApiExplorerSettings(GroupName = "admin")]

public class AuthorizationController(IUser user) : MainControllerBase<AuthorizationController>
{
    [HttpPost]
    public async Task<DefaultResponse<TokenResult>> SignIn(SignInRequest request)
        => await user.SignIn(request);

    /*[HttpPost("sign-up")]
    public async Task<DefaultResponse<TokenResult>> SignUp(SignUpRequest request)
        => await user.SignUp(request);*/
}