using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Organic.Database;
using Organic.Database.Models.Account;
namespace Organic;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<OrganicDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddIdentity<OrganicUser,OrganicRole>()
            .AddEntityFrameworkStores<OrganicDbContext>();

        builder.Services
            .AddControllersWithViews()
            .AddRazorRuntimeCompilation();
        builder.Services.AddRazorPages();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings.
            options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
            options.User.RequireUniqueEmail = true;
        });

        var app = builder.Build();

        app.UseStaticFiles();

        app.MapControllerRoute(
            name: "Areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
