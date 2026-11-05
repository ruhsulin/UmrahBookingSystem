using UmrahBookingSystem.Application.Common.Results;

namespace UmrahBookingSystem.Application.Common.Errors
{
    public static class FileStorageErrors
    {
        public static readonly Error Empty =
            new("FileStorage.Empty", "Please select a file.");
        public static readonly Error TooLarge =
            new("FileStorage.TooLarge", "The file is larger than 5 MB.");
        public static readonly Error UnsupportedType =
            new("FileStorage.UnsupportedType", "Only JPG, PNG and WEBP images are allowed.");
        public static readonly Error InvalidFolder =
            new("FileStorage.InvalidFolder", "This upload folder is not allowed.");
        public static readonly Error InvalidUrl =
            new("FileStorage.InvalidUrl", "This file URL is not valid.");
        public static readonly Error Unexpected =
            new("FileStorage.Unexpected", "Something went wrong while saving the file.");
    }
}
