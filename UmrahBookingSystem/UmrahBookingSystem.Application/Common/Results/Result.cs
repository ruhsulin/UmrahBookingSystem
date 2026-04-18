namespace UmrahBookingSystem.Application.Common.Results
{
    public class Result<T>
    {
        private readonly List<Error> _errors = new();
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public T? Value { get; }
        public IReadOnlyList<Error> Errors => _errors.AsReadOnly();

        private Result(bool isSuccess, T? value, IReadOnlyList<Error> errors)
        {
            if (isSuccess && errors.Any())
            {
                throw new ArgumentException("A successful result cannot contain errors.");
            }

            if (!isSuccess && !errors.Any())
            {
                throw new ArgumentException("A failed result must contain at least one error.");
            }

            IsSuccess = isSuccess;
            Value = value;

            if(errors.Any())
            {
                _errors.AddRange(errors);
            }
        }

        public static Result<T> Success(T value)
             => new Result<T>(isSuccess: true, value: value, errors: Array.Empty<Error>());

        public static Result<T> Failure(params Error[] errors)
            => new Result<T>(isSuccess: false, value: default, errors: errors);
    }
}
