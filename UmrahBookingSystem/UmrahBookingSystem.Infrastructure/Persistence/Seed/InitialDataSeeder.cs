using UmrahBookingSystem.Domain.Entities;
using UmrahBookingSystem.Infrastructure.Persistence.Context;

namespace UmrahBookingSystem.Infrastructure.Persistence.Seed
{
    public static class InitialDataSeeder
    {
        private static User SeedBootstrapAdmin(AppDbContext context)
        {
            // Check if system user already exists
            var existing = context.Users.FirstOrDefault(u => u.Id == "system");
            if (existing != null)
                return existing;

            var systemUser = new User
            {
                Id = "system",
                FirstName = "System",
                LastName = "Bootstrap",
                Email = "system@umrah.local",
                PhoneNumber = "0000000000",
                DateOfBirth = new DateTime(1991, 1, 1),
                LocationId = null, 
                RoleId = null, 
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            context.Users.Add(systemUser);
            context.SaveChanges();

            return systemUser;
        }

        private static UserRole SeedRoles(AppDbContext context, User createdBy)
        {
            var adminRole = context.UserRoles.FirstOrDefault(r => r.RoleName == "Admin");
            if(adminRole == null)
            {
                adminRole = new UserRole
                {
                    RoleName = "Admin",
                    CreatedBy = createdBy.Id,
                    CreatedAt = DateTime.UtcNow
                };
                context.UserRoles.Add(adminRole);
            }

            if(!context.UserRoles.Any(r => r.RoleName == "Client"))
            {
                context.UserRoles.Add(new UserRole
                {
                    RoleName = "Client",
                    CreatedBy = createdBy.Id,
                    CreatedAt = DateTime.UtcNow
                });
            }

            context.SaveChanges();
            return adminRole;
        }

        private static Country SeedCountries(AppDbContext context, User createdBy)
        {
            var countryNames = new[] { "Kosovo", "Albania", "Macedonia", "Saudi Arabia" };

            foreach (var name in countryNames)
            {
                if (!context.Countries.Any(c => c.CountryName == name)) 
                {
                    context.Countries.Add(new Country
                    {
                        CountryName = name,
                        CreatedBy = createdBy.Id,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            context.SaveChanges();
            return context.Countries.First(c => c.CountryName == "Kosovo"); 
        }

        private static City SeedCities(AppDbContext context, User createdBy, Country country)
        {
            var cityNames = new[] { "Pristina", "Prizren" };

            foreach (var name in cityNames)
            {
                if (!context.Cities.Any(c => c.CityName == name && c.CountryId == country.Id))
                {
                    context.Cities.Add(new City
                    {
                        CityName = name,       // ← verify this matches your actual City.cs
                        CountryId = country.Id,
                        CreatedBy = createdBy.Id,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            context.SaveChanges();
            return context.Cities.First(c => c.CityName == "Pristina" && c.CountryId == country.Id);
        }

        private static Location SeedLocations(AppDbContext context, User createdBy, City city)
        {
            var existing = context.Locations.FirstOrDefault(l =>
                l.CityId == city.Id && l.StreetName == "HQ");

            if (existing != null)
                return existing;

            var location = new Location
            {
                CityId = city.Id,
                StreetName = "HQ",
                DoorNumber = null,
                PostalCode = null,
                CreatedBy = createdBy.Id,
                CreatedAt = DateTime.UtcNow
            };

            context.Locations.Add(location);
            context.SaveChanges();

            return location;
        }


        private static void PromoteBootstrapAdmin(AppDbContext context, User admin, UserRole adminRole, Location location)
        {
            if (admin.RoleId != null && admin.LocationId != null)
                return;

            admin.RoleId = adminRole.Id;
            admin.LocationId = location.Id;

            context.SaveChanges();
        }
        public static void Seed(AppDbContext context)
        {
            var bootstrapAdmin = SeedBootstrapAdmin(context);
            var adminRole = SeedRoles(context, bootstrapAdmin);
            var country = SeedCountries(context, bootstrapAdmin);
            var city = SeedCities(context, bootstrapAdmin, country);
            var location = SeedLocations(context, bootstrapAdmin, city);
            PromoteBootstrapAdmin(context, bootstrapAdmin, adminRole, location);  // ← last, after everything else exists

        }
    }
}
