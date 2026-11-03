using UmrahBookingSystem.Application.Common.Results;
using UmrahBookingSystem.Application.DTOs.Hotels;

namespace UmrahBookingSystem.Application.Interfaces.Services
{
    public interface IHotelService
    {
        Task<Result<IEnumerable<HotelDto>>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Result<UpdateHotelDto>> GetForEditAsync(int id, CancellationToken cancellationToken = default);

        Task<Result<int>> CreateAsync(CreateHotelDto dto, CancellationToken cancellationToken = default);

        Task<Result<int>> UpdateAsync(UpdateHotelDto dto, CancellationToken cancellationToken = default);

        Task<Result<int>> DeleteAsync(int id, CancellationToken cancellationToken = default);

    }
}
