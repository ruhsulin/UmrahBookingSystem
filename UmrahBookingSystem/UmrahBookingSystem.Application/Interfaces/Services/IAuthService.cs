using UmrahBookingSystem.Application.Common.Results;

namespace UmrahBookingSystem.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<Result<string>> LoginAsync(string email, string password);

        Task LogoutAsync();
    }
}
