using MipiTestTask.Infrastructure.Exceptions;

namespace MipiTestTask.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (SdkException se)
        {
            _logger.LogError(se, se.Message);

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsJsonAsync(new { se.Message });
        }
        catch (NotFoundException nfe)
        {
            _logger.LogError(nfe, nfe.Message);

            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An unhandled exception occurred.: {ex.Message}");

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsJsonAsync(new { Message = $"An unexpected error occurred.: {ex.Message}" });
        }
    }
}