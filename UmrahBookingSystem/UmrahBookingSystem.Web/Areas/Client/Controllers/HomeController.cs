using Microsoft.AspNetCore.Mvc;

namespace UmrahBookingSystem.Web.Areas.Client.Controllers
{
    public class HomeController : ClientControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
