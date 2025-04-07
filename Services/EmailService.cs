using MailKit.Net.Smtp;
using MimeKit;
using TestForEmail.Interfaces;
using TestForEmail.Models;

namespace TestForEmail.Services;

public class EmailService : IEmail
{
    private readonly IConfiguration configuration;

    public EmailService(IConfiguration configuration)
    {
        this.configuration = configuration.GetSection("Email");
    }

    public async Task SendEmailAsync(Message message)
    {
        var mail = new MimeMessage();
        mail.From.Add(MailboxAddress.Parse(configuration["EmailAddress"]));
        mail.To.Add(MailboxAddress.Parse(message.To));
        
        mail.Subject = message.Subject;

        mail.Body = new TextPart("html", message.Body);

        var smtp = new SmtpClient();
        await smtp.ConnectAsync(configuration["Host"], 587, MailKit.Security.SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(configuration["EmailAddress"], configuration["Password"]);
        await smtp.SendAsync(mail);
        await smtp.DisconnectAsync(true);
    }
}
