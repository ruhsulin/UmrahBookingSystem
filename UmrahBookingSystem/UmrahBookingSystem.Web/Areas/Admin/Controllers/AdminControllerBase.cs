using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmrahBookingSystem.Web.Extensions;

namespace UmrahBookingSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = AuthorizationPolicies.AdminOnly)]
    public abstract class AdminControllerBase : Controller
    {
    }
}
