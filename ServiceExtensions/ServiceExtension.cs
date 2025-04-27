using TestForEmail.Interfaces;
using TestForEmail.Services;

namespace TestForEmail.ServiceExtension;

public static class ServiceExtension
{
    public static void AddCustomExtension(this IServiceCollection services)
    {
        services.AddScoped<IEmail, EmailService>();
        services.AddScoped<JwtService, JwtService>();
        services.AddScoped<UserService, UserService>();
    }
}
