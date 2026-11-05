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
                         .Include(h => h.HotelImages.OrderBy(i => i.Id).Take(1))
                         .AsNoTracking()
                         .ToListAsync(cancellationToken);
        }

        public async Task<Hotel?> GetByIdWithDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                         .Include(h => h.Location)
                         .Include(h => h.HotelImages)
                         .FirstOrDefaultAsync(h => h.Id == id, cancellationToken);
        }

        public async Task<bool> IsUsedInPackageAsync(int hotelId, CancellationToken cancellationToken = default)
        { 
            return await _dbContext.Set<PackageHotel>()
                         .AnyAsync(ph => ph.HotelId == hotelId, cancellationToken);
        }

        public void DeleteWithDetails(Hotel hotel)
        {

            _dbContext.Set<HotelImage>().RemoveRange(hotel.HotelImages.ToList()); 
            _dbSet.Remove(hotel);                                                
            _dbContext.Set<Location>().Remove(hotel.Location);
        }

        public void RemoveImage(HotelImage image)
        {
            _dbContext.Set<HotelImage>().Remove(image);
        }
    }
}