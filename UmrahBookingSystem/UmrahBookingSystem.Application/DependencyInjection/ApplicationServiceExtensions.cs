using Microsoft.Extensions.DependencyInjection;

namespace UmrahBookingSystem.Application.DependencyInjection
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
