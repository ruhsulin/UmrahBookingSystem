namespace UmrahBookingSystem.Application.Common.Results
{
    public sealed record Error(string Code, string Message)
    {
        public static readonly Error None = new(string.Empty, string.Empty);

        public static readonly Error NullValue = new Error("General.Null", "Null value was provided.");

        public static Error NotFound(string entity)
            => new($"{entity}.NotFound", $"{entity} was not found");
    }
}
