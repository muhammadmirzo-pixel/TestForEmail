using TestForEmail.Models;

namespace TestForEmail.ExceptionMiddleware;

public class CustomExtension
{
    private readonly RequestDelegate requestDelegate;
    private readonly ILogger<CustomExtension> logger;

    public CustomExtension(RequestDelegate requestDelegate, ILogger<CustomExtension> logger)
    {
        this.requestDelegate = requestDelegate;   
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {                                                                         
            await requestDelegate(context);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex.Message);
            await context.Response.WriteAsJsonAsync(new Responce
            {
                StatusdCode = 500,
                Message = ex.Message
            });
        }
    }
}
