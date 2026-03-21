using System;
using System.Collections.Generic;
using System.Text;

namespace UmrahBookingSystem.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomType { get; set; }
        public decimal RoomPrice { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
