using Application.Logics.User;
using Domain.Models.API.User;
using Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthorizationController(IUser user) : ControllerBase
{
    [HttpPost("sign-in")]
    public async Task<DefaultResponse<TokenResult>> SignIn(SignInRequest request)
        => await user.SignIn(request);

    [HttpPost("sign-up")]
    public async Task<DefaultResponse<TokenResult>> SignUp(SignUpRequest request)
        => await user.SignUp(request);
}