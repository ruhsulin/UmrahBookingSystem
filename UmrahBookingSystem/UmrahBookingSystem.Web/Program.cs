using UmrahBookingSystem.Application.DependencyInjection;
using UmrahBookingSystem.Infrastructure.DependencyInjection;
using UmrahBookingSystem.Infrastructure.Persistence.Context;
using UmrahBookingSystem.Infrastructure.Persistence.Seed;
using UmrahBookingSystem.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// 1. Exception handling (wraps everything)
app.UseGlobalExceptionHandling();

//  2. HTTPS (security first) - Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

// 3. Static files (serve CSS/JS/images without routing)
app.MapStaticAssets();

// 4. Routing (figure out which controller)
app.UseRouting();

// 5. Authentication (who are you?)
app.UseAuthentication();

// 6. Authorization (do you have permission?)
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//    InitialDataSeeder.SeedSystemUser(context);
//}

app.Run();
