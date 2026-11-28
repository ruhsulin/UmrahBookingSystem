using Microsoft.AspNetCore.Mvc;
using UmrahBookingSystem.Application.DTOs.Services;
using UmrahBookingSystem.Application.Interfaces.Services;
using UmrahBookingSystem.Web.Areas.Admin.ViewModels.Services;

namespace UmrahBookingSystem.Web.Areas.Admin.Controllers
{
    public class ServicesController : AdminControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await _serviceService.GetAllAsync(cancellationToken);

            if (result.IsFailure)
            {
                ViewData["Error"] = result.Errors[0].Message;
                return View(Enumerable.Empty<ServiceDto>());
            }

            return View(result.Value);
        }

        [HttpGet]
        public IActionResult Create() => View(new CreateServiceViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateServiceViewModel model, CancellationToken cancellationToken)
        {
            var dto = new CreateServiceDto { ServiceName = model.ServiceName };

            var result = await _serviceService.CreateAsync(dto, cancellationToken);
            if (result.IsFailure)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Message);

                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var result = await _serviceService.GetForEditAsync(id, cancellationToken);
            if (result.IsFailure || result.Value is null)
                return NotFound();

            return View(new EditServiceViewModel
            {
                Id = result.Value.Id,
                ServiceName = result.Value.ServiceName
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditServiceViewModel model, CancellationToken cancellationToken)
        {
            var dto = new UpdateServiceDto { Id = model.Id, ServiceName = model.ServiceName };

            var result = await _serviceService.UpdateAsync(dto, cancellationToken);
            if (result.IsFailure)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Message);

                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _serviceService.GetForEditAsync(id, cancellationToken);
            if (result.IsFailure || result.Value is null)
                return NotFound();

            return View(new DeleteServiceViewModel
            {
                Id = result.Value.Id,
                ServiceName = result.Value.ServiceName
            });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            var result = await _serviceService.DeleteAsync(id, cancellationToken);

            if (result.IsFailure)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Message);

                var service = await _serviceService.GetForEditAsync(id, cancellationToken);
                return View("Delete", new DeleteServiceViewModel
                {
                    Id = id,
                    ServiceName = service.Value?.ServiceName ?? string.Empty
                });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}