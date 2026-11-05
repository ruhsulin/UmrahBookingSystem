using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using UmrahBookingSystem.Application.Common.Errors;
using UmrahBookingSystem.Application.Common.Results;
using UmrahBookingSystem.Application.Interfaces.Services;

namespace UmrahBookingSystem.Infrastructure.Services
{
    public class LocalFileStorageService : IFileStorageService
    {
        private const long MaxFileSizeBytes = 5 * 1024 * 1024;   // 5 MB
        private const string UploadsRoot = "uploads";

        private static readonly HashSet<string> AllowedFolders =
            new(StringComparer.OrdinalIgnoreCase) { "hotels", "activities", "packages" };

        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<LocalFileStorageService> _logger;

        public LocalFileStorageService(IWebHostEnvironment environment,
                                       ILogger<LocalFileStorageService> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public async Task<Result<string>> SaveAsync(Stream content, string originalFileName,
            string folder, CancellationToken cancellationToken = default)
        {
            if (content is null || content.Length == 0)
                return Result<string>.Failure(FileStorageErrors.Empty);

            if (content.Length > MaxFileSizeBytes)
                return Result<string>.Failure(FileStorageErrors.TooLarge);

            if (!AllowedFolders.Contains(folder))
                return Result<string>.Failure(FileStorageErrors.InvalidFolder);

            var extension = Path.GetExtension(originalFileName).ToLowerInvariant();
            if (!await HasValidSignatureAsync(content, extension, cancellationToken))
                return Result<string>.Failure(FileStorageErrors.UnsupportedType);

            // Write to disk
            try
            {
                var safeFolder = folder.ToLowerInvariant();
                var folderPath = Path.Combine(_environment.WebRootPath, UploadsRoot, safeFolder);
                Directory.CreateDirectory(folderPath);  

                var fileName = $"{Guid.NewGuid()}{extension}";
                var fullPath = Path.Combine(folderPath, fileName);

                content.Position = 0;   
                await using var fileStream = new FileStream(fullPath, FileMode.CreateNew);
                await content.CopyToAsync(fileStream, cancellationToken);

                return Result<string>.Success($"/{UploadsRoot}/{safeFolder}/{fileName}");
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                _logger.LogError(ex, "Saving file to folder {Folder} failed.", folder);
                return Result<string>.Failure(FileStorageErrors.Unexpected);
            }
        }

        public Task<Result<bool>> DeleteAsync(string fileUrl, CancellationToken cancellationToken = default)
        {
            var parts = fileUrl?.Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (parts is null || parts.Length != 3
                || !parts[0].Equals(UploadsRoot, StringComparison.OrdinalIgnoreCase)
                || !AllowedFolders.Contains(parts[1])
                || parts[2] != Path.GetFileName(parts[2]))          
            {
                return Task.FromResult(Result<bool>.Failure(FileStorageErrors.InvalidUrl));
            }

            var fullPath = Path.Combine(_environment.WebRootPath, UploadsRoot,
                                        parts[1].ToLowerInvariant(), parts[2]);

            try
            {
                if (File.Exists(fullPath))
                    File.Delete(fullPath);

                return Task.FromResult(Result<bool>.Success(true));
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                _logger.LogError(ex, "Deleting file {FileUrl} failed.", fileUrl);
                return Task.FromResult(Result<bool>.Failure(FileStorageErrors.DeleteFailed));
            }
        }

        // Reads the first 12 bytes and compares them to the known image "magic bytes".
        private static async Task<bool> HasValidSignatureAsync(Stream content, string extension,
            CancellationToken cancellationToken)
        {
            var header = new byte[12];
            content.Position = 0;
            var read = await content.ReadAtLeastAsync(header, header.Length,
                throwOnEndOfStream: false, cancellationToken);
            if (read < header.Length)
                return false;

            return extension switch
            {
                ".jpg" or ".jpeg" => header.AsSpan(0, 3).SequenceEqual(new byte[] { 0xFF, 0xD8, 0xFF }),
                ".png" => header.AsSpan(0, 8).SequenceEqual(
                               new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }),
                ".webp" => header.AsSpan(0, 4).SequenceEqual("RIFF"u8)
                        && header.AsSpan(8, 4).SequenceEqual("WEBP"u8),
                _ => false   
            };
        }
    }
}