using System.Net;
using user_service.Exception;

namespace user_service.MiddleWares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // go to next middleware or endpoint
        }
        catch (System.Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    private Task HandleExceptionAsync(HttpContext context, System.Exception ex)
    {
        int statusCode;

        switch (ex)
        {
            case NotFoundException:
                statusCode = (int)HttpStatusCode.NotFound;
                break;
            case InvalidArgumentException:
                statusCode = (int)HttpStatusCode.BadRequest;
                break;

            default:
                statusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        var result = new
        {
            error = ex.Message,
            statusCode
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        return context.Response.WriteAsJsonAsync(result);
    }
}