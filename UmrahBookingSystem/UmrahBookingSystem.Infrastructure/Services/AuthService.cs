using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UmrahBookingSystem.Application.Common.Errors;
using UmrahBookingSystem.Application.Common.Results;
using UmrahBookingSystem.Application.DTOs.Auth;
using UmrahBookingSystem.Application.Interfaces.Services;
using UmrahBookingSystem.Domain.Constants;
using UmrahBookingSystem.Domain.Entities;
using UmrahBookingSystem.Infrastructure.Identity;
using UmrahBookingSystem.Infrastructure.Persistence.Context;

namespace UmrahBookingSystem.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;

        public AuthService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            AppDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        public async Task<Result<string>> RegisterAsync(RegisterDto dto)
        {
            var errors = ValidateRegistration(dto);
            if (errors.Count > 0)
                return Result<string>.Failure(errors.ToArray());

            var email = dto.Email.Trim();

            var emailTaken =
                await _userManager.FindByEmailAsync(email) is not null ||
                await _context.DomainUsers.AnyAsync(u => u.Email == email);

            if (emailTaken)
                return Result<string>.Failure(AuthErrors.EmailAlreadyRegistered);

            await using var transaction = await _context.Database.BeginTransactionAsync();

            var id = Guid.NewGuid().ToString();

            _context.DomainUsers.Add(new User
            {
                Id = id,
                FirstName = dto.FirstName.Trim(),
                LastName = dto.LastName.Trim(),
                Email = email,
                PhoneNumber = dto.PhoneNumber.Trim(),
                DateOfBirth = dto.DateOfBirth!.Value.Date,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            });
            await _context.SaveChangesAsync();

            var account = new ApplicationUser
            {
                Id = id,
                UserName = email,
                Email = email,
                EmailConfirmed = false
            };

            var created = await _userManager.CreateAsync(account, dto.Password);
            if (!created.Succeeded)
            {
                await transaction.RollbackAsync();
                return Result<string>.Failure(ToErrors(created));
            }

            var inRole = await _userManager.AddToRoleAsync(account, Roles.Client);
            if (!inRole.Succeeded)
            {
                await transaction.RollbackAsync();
                return Result<string>.Failure(ToErrors(inRole));
            }
            await transaction.CommitAsync();

            await _signInManager.SignInAsync(account, isPersistent: false);

            return Result<string>.Success(id);
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
            var role = roles.Contains(Roles.Admin) ? Roles.Admin : Roles.Client;

            return Result<string>.Success(role);
        }

        public Task LogoutAsync() => _signInManager.SignOutAsync();

        private static List<Error> ValidateRegistration(RegisterDto dto)
        {
            var errors = new List<Error>();
            var today = DateTime.UtcNow.Date;

            if (string.IsNullOrWhiteSpace(dto.FirstName))
                errors.Add(AuthErrors.FirstNameRequired);

            if (string.IsNullOrWhiteSpace(dto.LastName))
                errors.Add(AuthErrors.LastNameRequired);

            if (string.IsNullOrWhiteSpace(dto.Email))
                errors.Add(AuthErrors.EmailRequired);

            if (string.IsNullOrWhiteSpace(dto.PhoneNumber))
                errors.Add(AuthErrors.PhoneRequired);

            if (dto.DateOfBirth is null)
                errors.Add(AuthErrors.DateOfBirthRequired);
            else if (dto.DateOfBirth.Value.Date >= today)
                errors.Add(AuthErrors.DateOfBirthInFuture);
            else if (IsUnder18(dto.DateOfBirth.Value, today))
                errors.Add(AuthErrors.UnderAge);

            if (string.IsNullOrWhiteSpace(dto.Password))
                errors.Add(AuthErrors.PasswordRequired);
            else if (dto.Password != dto.ConfirmPassword)
                errors.Add(AuthErrors.PasswordsDoNotMatch);

            return errors;
        }

        private static bool IsUnder18(DateTime dateOfBirth, DateTime today)
            => dateOfBirth.Date.AddYears(18) > today;

        private static Error[] ToErrors(IdentityResult result)
           => result.Errors.Select(e => new Error($"Auth.{e.Code}", e.Description)).ToArray();
    }
}
