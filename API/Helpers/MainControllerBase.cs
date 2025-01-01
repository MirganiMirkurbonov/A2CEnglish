using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;

namespace API.Helpers;

public class MainControllerBase<T> : ControllerBase where T : class
{
    protected Guid CurrentUserId => Guid.Parse(User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value);
}