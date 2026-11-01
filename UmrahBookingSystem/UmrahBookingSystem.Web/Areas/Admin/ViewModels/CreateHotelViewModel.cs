using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UmrahBookingSystem.Web.Areas.Admin.ViewModels
{
    public class CreateHotelViewModel
    {
        public string HotelName { get; set; } = string.Empty;
        public int Stars { get; set; }
        public int CityId { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string? DoorNumber { get; set; }
        public string? PostalCode { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> Cities { get; set; } = new List<SelectListItem>();
    }
}
