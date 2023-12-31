namespace ConsoleQueries.Middleware;

public class ExceptionHandlerMiddleware:IMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (NullReferenceException ex)
        {
            context.Response.StatusCode = 500;
            _logger.LogError(ex.Message);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            _logger.LogError(ex.StackTrace);
            _logger.LogError(ex.Message);
        }
    }
}
