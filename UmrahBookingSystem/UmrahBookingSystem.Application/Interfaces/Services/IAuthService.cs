using UmrahBookingSystem.Application.Common.Results;
using UmrahBookingSystem.Application.DTOs.Auth;

namespace UmrahBookingSystem.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<Result<string>> LoginAsync(string email, string password);

        Task LogoutAsync();
        Task<Result<string>> RegisterAsync(RegisterDto dto);
    }
}
