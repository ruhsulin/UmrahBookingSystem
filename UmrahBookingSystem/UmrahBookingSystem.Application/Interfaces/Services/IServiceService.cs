using UmrahBookingSystem.Application.Common.Results;
using UmrahBookingSystem.Application.DTOs.Services;

namespace UmrahBookingSystem.Application.Interfaces.Services
{
    public interface IServiceService
    {
        Task<Result<IEnumerable<ServiceDto>>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Result<UpdateServiceDto>> GetForEditAsync(int id, CancellationToken cancellationToken = default);

        Task<Result<int>> CreateAsync(CreateServiceDto dto, CancellationToken cancellationToken = default);

        Task<Result<int>> UpdateAsync(UpdateServiceDto dto, CancellationToken cancellationToken = default);

        Task<Result<int>> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}