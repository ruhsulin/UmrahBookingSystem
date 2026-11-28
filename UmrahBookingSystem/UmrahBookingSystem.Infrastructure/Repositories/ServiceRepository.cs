using Microsoft.EntityFrameworkCore;
using UmrahBookingSystem.Application.Interfaces.Repositories;
using UmrahBookingSystem.Domain.Entities;
using UmrahBookingSystem.Infrastructure.Persistence.Context;

namespace UmrahBookingSystem.Infrastructure.Repositories
{
    public class ServiceRepository : GenericRepository<Service, int>, IServiceRepository
    {
        public ServiceRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<bool> NameExistsAsync(string serviceName, int? excludeId = null, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                         .AnyAsync(s => s.ServiceName == serviceName
                                     && (excludeId == null || s.Id != excludeId), cancellationToken);
        }

        public async Task<bool> IsUsedInPackageAsync(int serviceId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<PackageService>()
                         .AnyAsync(ps => ps.ServiceId == serviceId, cancellationToken);
        }
    }
}