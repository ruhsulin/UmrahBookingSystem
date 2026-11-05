using UmrahBookingSystem.Application.Common.Results;

namespace UmrahBookingSystem.Application.Interfaces.Services
{
    public interface IFileStorageService
    {
        // Returns the relative YRL
        Task<Result<string>> SaveAsync(Stream content, string originalFileName, string folder,
            CancellationToken cancellationToken = default);

        Task<Result<bool>> DeleteAsync(string fileUrl, CancellationToken cancellationToken = default);
    }
}
