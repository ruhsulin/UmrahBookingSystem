using Microsoft.EntityFrameworkCore;
using UmrahBookingSystem.Application.Interfaces.Repositories;
using UmrahBookingSystem.Domain.Entities;
using UmrahBookingSystem.Infrastructure.Persistence.Context;

namespace UmrahBookingSystem.Infrastructure.Repositories
{
    public class HotelRepository : GenericRepository<Hotel, int>, IHotelRepository
    {
        public HotelRepository(AppDbContext dbContext) : base(dbContext) { }
       
        public async Task<IEnumerable<Hotel>> GetAllWithCityAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet
                         .Include(h => h.Location)
                         .ThenInclude(l => l.City)
                         .AsNoTracking()
                         .ToListAsync(cancellationToken);
        }

        public async Task<Hotel?> GetByIdWithLocationAsync(int id, CancellationToken cancellationToken = default)
        {
            // Tracked on purpose (no AsNoTracking): we will change and save this entity.
            return await _dbSet
                         .Include(h => h.Location)
                         .FirstOrDefaultAsync(h => h.Id == id, cancellationToken);
        }

        public async Task<bool> IsUsedInPackageAsync(int hotelId, CancellationToken cancellationToken = default)
        {
            // The global query filter already skips soft-deleted PackageHotel rows.
            return await _dbContext.Set<PackageHotel>()
                         .AnyAsync(ph => ph.HotelId == hotelId, cancellationToken);
        }
    }
}
