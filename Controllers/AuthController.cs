using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestForEmail.Models;
using TestForEmail.Services;

namespace TestForEmail.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(UserService userService, JwtService jwtService) : ControllerBase
{

    [HttpPost("signup")]
    public IActionResult SignUp([FromBody] User user)
    {
        if (userService.GetByEmail(user.Email) is not null)
            return BadRequest("Email already exists");

        userService.Register(user);
        return Ok("Registered successfully");
    }

    [HttpPost("signin")]
    public IActionResult SignIn([FromBody] User login)
    {
        var user = userService.GetByEmail(login.Email);
        if (user == null || user.Password != login.Password)
            return Unauthorized("Invalid credentials");

        var token = jwtService.GenerateToken(user);
        return Ok(new { Token = token });
    }
}
