using UmrahBookingSystem.Domain.Entities;

namespace UmrahBookingSystem.Application.Interfaces.Repositories
{
    public interface IHotelRepository : IGenericRepository<Hotel, int>
    {
        Task<IEnumerable<Hotel>> GetAllWithCityAsync(CancellationToken cancellationToken = default);

        Task<Hotel?> GetByIdWithLocationAsync(int id, CancellationToken cancellationToken = default);

        Task<bool> IsUsedInPackageAsync(int hotelId, CancellationToken cancellationToken = default);
    }
}
