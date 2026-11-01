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
    }
}
