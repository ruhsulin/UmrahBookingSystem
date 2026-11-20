using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using UmrahBookingSystem.Application.Common.Errors;
using UmrahBookingSystem.Application.Common.Results;
using UmrahBookingSystem.Application.Interfaces.Services;
using UmrahBookingSystem.Infrastructure.Identity;

namespace UmrahBookingSystem.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<Result<string>> LoginAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return Result<string>.Failure(AuthErrors.InvalidCredentials);
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                return Result<string>.Failure(AuthErrors.InvalidCredentials);
            }

            var result = await _signInManager.PasswordSignInAsync(
                user, password, isPersistent: false, lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                return Result<string>.Failure(AuthErrors.InvalidCredentials);
            }

            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.Contains("Admin") ? "Admin" : "Client";

            return Result<string>.Success(role);
        }

        public Task LogoutAsync() => _signInManager.SignOutAsync();
    }
}
