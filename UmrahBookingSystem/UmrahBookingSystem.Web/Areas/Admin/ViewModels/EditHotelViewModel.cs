using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using UmrahBookingSystem.Application.DTOs.Hotels;

namespace UmrahBookingSystem.Web.Areas.Admin.ViewModels
{
    public class EditHotelViewModel
    {
        public int Id { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public int Stars { get; set; }
        public int CityId { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string? DoorNumber { get; set; }
        public string? PostalCode { get; set; }
        public List<IFormFile> Images { get; set; } = new();

        [ValidateNever]
        public IEnumerable<SelectListItem> Cities { get; set; } = new List<SelectListItem>();

        [ValidateNever]
        public List<HotelImageDto> ExistingImages { get; set; } = new();


    }
}
