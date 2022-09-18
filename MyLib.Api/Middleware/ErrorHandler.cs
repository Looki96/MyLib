namespace MyLib.Api.Middleware
{
    public class ErrorHandler : IMiddleware
    {
        private readonly ILogger<ErrorHandler> _logger;

        public ErrorHandler(ILogger<ErrorHandler> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (BadRequestException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (ForbiddenException ex)
            {
                context.Response.StatusCode = 403;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong.");
            }
        }
    }
}
