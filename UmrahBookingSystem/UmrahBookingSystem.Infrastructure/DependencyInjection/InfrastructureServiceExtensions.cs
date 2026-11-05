using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UmrahBookingSystem.Application.Interfaces.Repositories;
using UmrahBookingSystem.Application.Interfaces.Services;
using UmrahBookingSystem.Infrastructure.Persistence.Context;
using UmrahBookingSystem.Infrastructure.Persistence.Seed;
using UmrahBookingSystem.Infrastructure.Repositories;
using UmrahBookingSystem.Infrastructure.Services;

namespace UmrahBookingSystem.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(
              this IServiceCollection services,
              IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            services.AddRepositories();
            services.AddServices();
            services.AddHttpContextAccessor();

            return services;
        }

        private static IServiceCollection AddPersistence(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

                options.UseSeeding((context, _) =>
                {
                    InitialDataSeeder.Seed((AppDbContext)context);
                });

                options.UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    InitialDataSeeder.Seed((AppDbContext)context);
                    await Task.CompletedTask;
                });
            });

            return services;  
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<ICityRepository, CityRepository>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFileStorageService, LocalFileStorageService>();

            return services;
        }
    }
}
