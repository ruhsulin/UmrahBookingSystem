using UmrahBookingSystem.Application.Common.Results;

namespace UmrahBookingSystem.Application.Interfaces.Services
{
    public interface IFileStorageService
    {
        // Returns the relative YRL
        Task<Result<string>> SaveAsync(Stream content, string originalFileName, string folder);

        Task<Result<bool>> DeleteAsync(string fileUrl);
    }
}
