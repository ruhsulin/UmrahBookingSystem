using System.Text.Json;

namespace UmrahBookingSystem.Web.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (Exception exception)
            {
                _logger.LogError(exception, "An unhandled exception occurred.");

                if (context.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, the error handler will not execute.");
                    throw;
                }

                if (WantsJson(context))
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";

                    var response = new
                    {
                        message = "An unexpected error occurred.",
                        statusCode = StatusCodes.Status500InternalServerError
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    return;
                }

                context.Response.Redirect("/Home/Error");
                return;
            }
        }

        private static bool WantsJson(HttpContext context)
        {
            var acceptHeader = context.Request.Headers.Accept.ToString();

            return !string.IsNullOrWhiteSpace(acceptHeader) &&
                   acceptHeader.Contains("application/json", StringComparison.OrdinalIgnoreCase);
        }
    }
}