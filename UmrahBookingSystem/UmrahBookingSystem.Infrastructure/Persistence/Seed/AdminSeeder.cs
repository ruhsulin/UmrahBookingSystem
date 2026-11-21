using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UmrahBookingSystem.Domain.Entities;
using UmrahBookingSystem.Infrastructure.Identity;
using UmrahBookingSystem.Infrastructure.Persistence.Context;

namespace UmrahBookingSystem.Infrastructure.Persistence.Seed
{
    public static class AdminSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            var section = services.GetRequiredService<IConfiguration>().GetSection("Seed:Admin");

            var email = section["Email"];
            var password = section["Password"];

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return;

            var context = services.GetRequiredService<AppDbContext>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            // Idempotent: the admin already exists, nothing to do.
            if (await userManager.FindByEmailAsync(email) is not null)
                return;

            await using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var id = Guid.NewGuid().ToString();

                context.DomainUsers.Add(new User
                {
                    Id = id,
                    FirstName = section["FirstName"] ?? "System",
                    LastName = section["LastName"] ?? "Admin",
                    Email = email,
                    PhoneNumber = section["PhoneNumber"] ?? "0000000000",
                    DateOfBirth = DateTime.Parse(
                        section["DateOfBirth"] ?? "2000-01-01", CultureInfo.InvariantCulture),
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                });
                await context.SaveChangesAsync();

                var account = new ApplicationUser
                {
                    Id = id,
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                var created = await userManager.CreateAsync(account, password);
                if (!created.Succeeded)
                    throw new InvalidOperationException(
                        "Admin seed failed: " + string.Join("; ", created.Errors.Select(e => e.Description)));

                var inRole = await userManager.AddToRoleAsync(account, "Admin");
                if (!inRole.Succeeded)
                    throw new InvalidOperationException(
                        "Admin seed failed: " + string.Join("; ", inRole.Errors.Select(e => e.Description)));

                await transaction.CommitAsync();
            }
            catch (DbUpdateException)
            {
         
            }
        }
    }
}
