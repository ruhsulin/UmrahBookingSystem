using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmrahBookingSystem.Web.Extensions;

namespace UmrahBookingSystem.Web.Areas.Client.Controllers
{
    [Area("Client")]
    [Authorize(Policy = AuthorizationPolicies.ClientOnly)]
    public abstract class ClientControllerBase : Controller
    { }
}
