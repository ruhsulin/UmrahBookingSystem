
using UmrahBookingSystem.Application.Common.Results;
using UmrahBookingSystem.Application.DTOs.Cities;

namespace UmrahBookingSystem.Application.Interfaces.Services
{
    public interface ICityService
    {
        Task<Result<IEnumerable<CityDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
