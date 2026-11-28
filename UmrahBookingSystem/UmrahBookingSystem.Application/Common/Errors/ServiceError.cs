using UmrahBookingSystem.Application.Common.Results;

namespace UmrahBookingSystem.Application.Common.Errors
{
    public static class ServiceErrors
    {
        public static readonly Error NotFound = Error.NotFound("Service");

        public static readonly Error NameRequired =
            new("Service.NameRequired", "Service name is required.");

        public static readonly Error NameTooLong =
            new("Service.NameTooLong", "Service name cannot be longer than 250 characters.");

        public static readonly Error DuplicateName =
            new("Service.DuplicateName", "A service with this name already exists.");

        public static readonly Error InUse =
            new("Service.InUse", "This service is used in a package and cannot be deleted.");
    }
}