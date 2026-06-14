using CatBaBooking.Models;
using CatBaBooking.Service;
using Microsoft.EntityFrameworkCore;

namespace CatBaBooking;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<CatBaBookingContext>();
        builder.Services.AddDbContext<CatBaBookingContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));
        builder.Services.Scan(scan => scan
                .FromAssemblyOf<LoginService>() 
                .AddClasses(classes => classes
                    .Where(type => type.Name.EndsWith("Service"))) 
                .AsImplementedInterfaces() 
                .WithScopedLifetime()
        );
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
        
        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseSession();
        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=dashboard}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}