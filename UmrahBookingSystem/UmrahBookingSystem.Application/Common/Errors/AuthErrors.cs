using UmrahBookingSystem.Application.Common.Results;

namespace UmrahBookingSystem.Application.Common.Errors
{
    public static class AuthErrors
    {
        public static readonly Error InvalidCredentials =
           new("Auth.InvalidCredentials", "Invalid email or password.");
    }
}
