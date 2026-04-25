namespace UmrahBookingSystem.Web.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<UmrahBookingSystem.Web.Middleware.ExceptionHandlingMiddleware>();
        }
    }
}
