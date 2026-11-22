using Microsoft.AspNetCore.Mvc;

namespace UmrahBookingSystem.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminControllerBase
    {
        public IActionResult Index() => View();
    }
}
