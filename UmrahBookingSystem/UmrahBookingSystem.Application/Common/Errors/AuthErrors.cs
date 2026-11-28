using UmrahBookingSystem.Application.Common.Results;

namespace UmrahBookingSystem.Application.Common.Errors
{
    public static class AuthErrors
    {
        public static readonly Error InvalidCredentials =
           new("Auth.InvalidCredentials", "Invalid email or password.");

        public static readonly Error FirstNameRequired =
    new("Auth.FirstNameRequired", "First name is required.");

        public static readonly Error LastNameRequired =
            new("Auth.LastNameRequired", "Last name is required.");

        public static readonly Error EmailRequired =
            new("Auth.EmailRequired", "Email is required.");

        public static readonly Error PhoneRequired =
            new("Auth.PhoneRequired", "Phone number is required.");

        public static readonly Error DateOfBirthRequired =
            new("Auth.DateOfBirthRequired", "Date of birth is required.");

        public static readonly Error DateOfBirthInFuture =
            new("Auth.DateOfBirthInFuture", "Date of birth must be in the past.");

        public static readonly Error UnderAge =
            new("Auth.UnderAge", "You must be at least 18 years old to register.");

        public static readonly Error PasswordRequired =
            new("Auth.PasswordRequired", "Password is required.");

        public static readonly Error PasswordsDoNotMatch =
            new("Auth.PasswordsDoNotMatch", "Passwords do not match.");

        public static readonly Error EmailAlreadyRegistered =
            new("Auth.EmailAlreadyRegistered", "This email is already registered.");
    }
}
