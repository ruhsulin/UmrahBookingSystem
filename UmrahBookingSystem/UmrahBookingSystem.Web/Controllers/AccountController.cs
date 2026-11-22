using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmrahBookingSystem.Application.Interfaces.Services;
using UmrahBookingSystem.Domain.Constants;
using UmrahBookingSystem.Web.ViewModels;

namespace UmrahBookingSystem.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _authService.LoginAsync(model.Email, model.Password);

            if (result.IsFailure)
            {
                ModelState.AddModelError(string.Empty, result.Errors[0].Message);
                return View(model);
            }

            // Only follow a returnUrl that points to our own site (open redirect protection).
            if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                return LocalRedirect(model.ReturnUrl);

            return result.Value == Roles.Admin
                ? LocalRedirect("/admin")
                : LocalRedirect("/");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return LocalRedirect("/");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
