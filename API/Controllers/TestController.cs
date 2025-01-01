using Domain.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
[AutoPermission]
[Authorize]
public class TestController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> TestMe()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}