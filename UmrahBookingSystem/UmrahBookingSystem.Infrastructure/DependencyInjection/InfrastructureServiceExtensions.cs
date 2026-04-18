using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UmrahBookingSystem.Application.Interfaces.Repositories;
using UmrahBookingSystem.Infrastructure.Persistence.Context;
using UmrahBookingSystem.Infrastructure.Repositories;

namespace UmrahBookingSystem.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceextensions
    {
        public static IServiceCollection AddInfrastructureServices(
              this IServiceCollection services,
              IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            services.AddRepositories();
            services.AddHttpContextAccessor();

            return services;
        }

        private static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
