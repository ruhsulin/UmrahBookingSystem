using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Application.Interfaces.Repositories
{
    public interface IServiceRepository : IGenericRepository<Service, int>
    {
        Task<bool> NameExistsAsync(string serviceName, int? excludeId = null, CancellationToken cancellationToken = default);

        Task<bool> IsUsedInPackageAsync(int serviceId, CancellationToken cancellationToken = default);
    }
}