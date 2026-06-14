using System.Text.Json;

namespace LiquidLabsDemo.API.Helpers
{
    public sealed class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        public GlobalExceptionHandlingMiddleware(
        RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                _logger.LogError(
              exception,
              "Unhandled exception occurred while processing request.");
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var response = new
                {
                    statusCode = 500,
                    message = "An unexpected error occurred. Please try again later."
                };

                var json = JsonSerializer.Serialize(response);

                await httpContext.Response.WriteAsync(json);
            }
        }

    }
}
