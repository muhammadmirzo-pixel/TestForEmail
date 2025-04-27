using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestForEmail.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult GetProfile()
    {
        var email = User.FindFirst("email")?.Value;
        return Ok(new { Message = "Welcome to your profile", Email = email });
    }
}
