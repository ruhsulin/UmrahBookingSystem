using Microsoft.AspNetCore.Mvc;
using UmrahBookingSystem.Application.DTOs.Hotels;
using UmrahBookingSystem.Application.Interfaces.Services;

namespace UmrahBookingSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HotelsController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await _hotelService.GetAllAsync(cancellationToken);

            if (result.IsFailure)
            {
                ViewData["Error"] = result.Errors[0].Message;
                return View(Enumerable.Empty<HotelDto>());
            }

            return View(result.Value);
        }
    }
}
