using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UmrahBookingSystem.Application.DTOs.Hotels;
using UmrahBookingSystem.Application.Interfaces.Services;
using UmrahBookingSystem.Web.Areas.Admin.ViewModels;

namespace UmrahBookingSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HotelsController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly ICityService _cityService;

        public HotelsController(IHotelService hotelService, ICityService cityService)
        {
            _hotelService = hotelService;
            _cityService = cityService;
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

        [HttpGet]
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var model = new CreateHotelViewModel
            {
                Cities = await GetCityOptionsAsync(cancellationToken)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateHotelViewModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                model.Cities = await GetCityOptionsAsync(cancellationToken);
                return View(model);
            }

            var dto = new CreateHotelDto
            {
                HotelName = model.HotelName,
                Stars = model.Stars,
                CityId = model.CityId,
                StreetName = model.StreetName,
                DoorNumber = model.DoorNumber,
                PostalCode = model.PostalCode
            };

            var result = await _hotelService.CreateAsync(dto, cancellationToken);

            if (result.IsFailure)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Message);

                model.Cities = await GetCityOptionsAsync(cancellationToken);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<IEnumerable<SelectListItem>> GetCityOptionsAsync(CancellationToken cancellationToken)
        {
            var result = await _cityService.GetAllAsync(cancellationToken);
            if (result.IsFailure || result.Value is null)
                return Enumerable.Empty<SelectListItem>();

            return result.Value
                .OrderBy(c => c.CityName)
                .Select(c => new SelectListItem(c.CityName, c.Id.ToString()));
        }
    }
}
