using Microsoft.AspNetCore.Mvc;
using TestForEmail.Interfaces;
using TestForEmail.Models;

namespace TestForEmail.Controllers;

[Controller]
[Route("api/[controller]")]
public class EmailController :ControllerBase
{
    private readonly IEmail emailService;
    public EmailController(IEmail emailService)
    {
        this.emailService = emailService;
    }

    [HttpPost]
    public async Task<IActionResult> Send(Message message)
    {
        await this.emailService.SendEmailAsync(message);
        return Ok(message);
    }
}
