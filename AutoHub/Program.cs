using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoHub.Data;
namespace AutoHub
{
    using AutoHub.Data;
    using AutoHub.Data.Configuration;
    using AutoHub.Data.Models;
    using AutoHub.Infrastructure.Repositories;
    using AutoHub.Infrastructure.Repositories.Interfaces;
    using AutoHub.Infrastructure.Services;
    using AutoHub.Infrastructure.Services.Interfaces;
    using Microsoft.AspNetCore.Authentication.Cookies;
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
            builder.Services
             .AddDefaultIdentity<IdentityUser>(cfg =>
            {
                cfg.Password.RequireDigit = true;

                cfg.Password.RequireLowercase = true;

                cfg.Password.RequireUppercase = true;

                cfg.Password.RequireNonAlphanumeric = false;

                cfg.Password.RequiredLength = 6;

                cfg.Password.RequiredUniqueChars = 0;

                cfg.SignIn.RequireConfirmedAccount = false;

                cfg.SignIn.RequireConfirmedPhoneNumber = false;

                cfg.User.RequireUniqueEmail = false;

                cfg.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);
                cfg.Lockout.MaxFailedAccessAttempts = 3;
                cfg.Lockout.AllowedForNewUsers = true;
            })
            .AddRoles <IdentityRole>()
            .AddEntityFrameworkStores<AutoHubDbContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Home/Error403";
            });

            //Registering repos in DI
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IModelRepository, ModelRepository>();
            builder.Services.AddScoped<IGearboxRepository, GearboxRepository>();
            builder.Services.AddScoped<IEngineRepository, EngineRepository>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IHydraulicSystemRepository, HydraulicSystemRepository>();

            //Registering services in DI
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<IModelService, ModelService>();
            builder.Services.AddScoped<IEngineService, EngineService>();
            builder.Services.AddScoped<IGearboxService, GearboxService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IHydraulicSystemService, HydraulicSystemService>();

            var app = builder.Build();

            //Seeding Roles
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<AutoHubDbContext>();
                    DatabaseSeeder.SeedAsync(context, services).GetAwaiter().GetResult();
                    DatabaseSeeder.AssignAdminRole(context, services).GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred during role seeding: {ex.Message}");
                }
            }

            //// Configure the HTTP request pipeline.
            //// Configure Error pages and handling.
            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            
            app.UseAuthentication();
            
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "Areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

            app.MapControllerRoute(
                name: "Errors",
                pattern: "{controller=Home}/{action=Error}/{statusCode?}");

            app.MapControllerRoute(
                name: "Admin",
                pattern: "{controller=Admin}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

			// Enable Identity's Razor Pages for login, register 
			app.MapRazorPages();

			app.Run();
        }
    }
}
