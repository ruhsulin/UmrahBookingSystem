using UmrahBookingSystem.Application.Common.Results;

namespace UmrahBookingSystem.Application.Common.Errors
{
    public static class HotelErrors
    {
        // Existing (moved from HotelService)
        public static readonly Error NotFound = Error.NotFound("Hotel");

        public static readonly Error NameRequired =
            new("Hotel.NameRequired", "Hotel name is required.");

        public static readonly Error StarsOutOfRange =
            new("Hotel.StarsOutOfRange", "Hotel stars must be between 1 and 5.");

        public static readonly Error CityRequired =
            new("Hotel.CityRequired", "City is required.");

        public static readonly Error StreetRequired =
            new("Hotel.StreetRequired", "Street name is required.");

        public static readonly Error InUse =
            new("Hotel.InUse", "This hotel is used in a package and cannot be deleted.");

        // New for UBS-58
        public static readonly Error ImageNotFound = Error.NotFound("HotelImage");

        public static Error TooManyImages(int max) =>
            new("Hotel.TooManyImages", $"A hotel can have at most {max} images.");
    }
}