using System;
using System.Collections.Generic;
using System.Text;
using UmrahBookingSystem.Domain.Entities;
using UmrahBookingSystem.Infrastructure.Persistence.Context;

namespace UmrahBookingSystem.Infrastructure.Persistence.Seed
{
    public class InitialDataSeeder
    {
        public static void SeedSystemUser(AppDbContext context)
        {
            // Check if system user already exists
            if (context.Users.Any(u => u.Id == "system"))
                return;

            var systemUser = new User
            {
                Id = "system",
                FirstName = "System",
                LastName = "Bootstrap",
                Email = "system@umrah.local",
                PhoneNumber = "0000000000",
                DateOfBirth = DateTime.Now,
                LocationId = null, // ← This should NOT throw an error now
                RoleId = null, // Temporary; we'll seed roles in UBS-22
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            context.Users.Add(systemUser);
            context.SaveChanges();
        }
    }
}
