using Microsoft.Extensions.DependencyInjection;
using UmrahBookingSystem.Application.Interfaces.Services;
using UmrahBookingSystem.Application.Services;

namespace UmrahBookingSystem.Application.DependencyInjection
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingService, BookingService>();
            return services;
        }
    }
}
