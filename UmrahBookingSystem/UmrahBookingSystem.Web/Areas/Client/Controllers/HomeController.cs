using Microsoft.AspNetCore.Mvc;

namespace UmrahBookingSystem.Web.Areas.Client.Controllers
{
    [Area("Client")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
