using System.Net;
using System.Text.Json;

namespace OnlineShop.WebAPI.Middlewares;

public class ApiExceptionHandlingMiddleware
{
    #region constrctor

    private readonly RequestDelegate _next;
    //private readonly ILogger<ApiExceptionHandlingMiddleware> _logger;
    public ApiExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    #endregion

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(ex.Message);
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(result);
    }
}
