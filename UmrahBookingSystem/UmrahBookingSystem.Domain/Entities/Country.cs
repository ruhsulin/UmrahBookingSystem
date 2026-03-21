using System;
using System.Collections.Generic;
using System.Text;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public required string CountryName { get; set; }
        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
