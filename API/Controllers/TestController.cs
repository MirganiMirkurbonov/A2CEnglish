using Domain.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
[AutoPermission]
public class TestController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> TestMe()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}