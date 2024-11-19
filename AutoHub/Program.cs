using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoHub.Data;
namespace AutoHub
{
    using AutoHub.Data;
    using AutoHub.Data.Models;
    using AutoHub.Infrastructure.Repositories;
    using AutoHub.Infrastructure.Repositories.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AutoHubDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer"));
            });

            // Add Identity services
            builder.Services.AddDefaultIdentity<IdentityUser>(cfg =>
            {
                cfg.Password.RequireDigit = true;

                cfg.Password.RequireLowercase = true;

                cfg.Password.RequireUppercase = true;

                cfg.Password.RequireNonAlphanumeric = false;

                cfg.Password.RequiredLength = 6;

                cfg.Password.RequiredUniqueChars = 0;

                cfg.SignIn.RequireConfirmedAccount = false;

                cfg.SignIn.RequireConfirmedAccount = false;

                cfg.SignIn.RequireConfirmedPhoneNumber = false;

                cfg.User.RequireUniqueEmail = false;

                cfg.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);
                cfg.Lockout.MaxFailedAccessAttempts = 3;
                cfg.Lockout.AllowedForNewUsers = true;
            })
            .AddEntityFrameworkStores<AutoHubDbContext>();

            //Registering repos in DI
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IModelRepository, ModelRepository>();
            builder.Services.AddScoped<IGearboxRepository, GearboxRepository>();
            builder.Services.AddScoped<IEngineRepository, EngineRepository>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Add Authorization and Authentication middleware
            app.UseAuthentication();
            app.UseAuthorization();

            // Enable Identity's Razor Pages for login, register 
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
