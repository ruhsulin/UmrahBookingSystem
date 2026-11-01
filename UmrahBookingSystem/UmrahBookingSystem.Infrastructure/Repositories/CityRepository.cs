using UmrahBookingSystem.Application.Interfaces.Repositories;
using UmrahBookingSystem.Domain.Entities;
using UmrahBookingSystem.Infrastructure.Persistence.Context;

namespace UmrahBookingSystem.Infrastructure.Repositories
{
    public class CityRepository : GenericRepository<City, int>, ICityRepository
    {
        public CityRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
