using System.Net;
using System.Text.Json;
using ISP.BLL.Exceptions;

namespace ISP.API.Middleware;

public class ExceptionHandlingMiddleware(
    RequestDelegate next, 
    IHostEnvironment env)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var errorResponse = CreateErrorResponse(exception);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)errorResponse.Status;

        var result = JsonSerializer.Serialize($"{errorResponse.ErrorDescription}: {errorResponse.ErrorMessage}");
        await context.Response.WriteAsync(result);
    }

    private ErrorResponse CreateErrorResponse(Exception exception)
    {
        HttpStatusCode status;
        string errorDescription, errorMessage;

        switch (exception)
        {
            case NotFoundException:
                status = HttpStatusCode.NotFound;
                errorDescription = "Not Found Error";
                errorMessage = exception.Message;
                break;
            case AuthException:
                status = HttpStatusCode.BadRequest;
                errorDescription = "Auth Error";
                errorMessage = exception.Message;
                break;
            case InvalidOperationException:
                status = HttpStatusCode.BadRequest;
                errorDescription = "Invalid Operation Error";
                errorMessage = exception.Message;
                break;
            default:
                status = HttpStatusCode.InternalServerError;
                errorDescription = "Internal Server Error";
                errorMessage = env.IsDevelopment() ? exception.Message : "An unexpected error occurred.";
                break;
        }

        return new ErrorResponse(status, errorDescription, errorMessage);
    }

    private record ErrorResponse(HttpStatusCode Status, string ErrorDescription, string ErrorMessage);
}

public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}