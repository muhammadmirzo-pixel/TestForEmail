using TestForEmail.Models;

namespace TestForEmail.Interfaces;

public interface IEmail
{
    Task SendEmailAsync(Message message);
}
