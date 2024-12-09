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

            //Registering repos in DI
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IModelRepository, ModelRepository>();
            builder.Services.AddScoped<IGearboxRepository, GearboxRepository>();
            builder.Services.AddScoped<IEngineRepository, EngineRepository>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            //Registering services in DI
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<IModelService, ModelService>();
            builder.Services.AddScoped<IEngineService, EngineService>();
            builder.Services.AddScoped<IGearboxService, GearboxService>();
            builder.Services.AddScoped<IProductService, ProductService>();

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

            // Configure the HTTP request pipeline.
            // Configure Error pages and handling.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }
           

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Add Authorization and Authentication middleware
            app.UseAuthentication();

            //TODO add Middleware for pages redirect based on the role of the user

            app.UseAuthorization();

            app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");

			app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

            app.MapControllerRoute(
                name: "Errors",
                pattern: "{controller=Home}/{action=Index}/{statusCode?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

			// Enable Identity's Razor Pages for login, register 
			app.MapRazorPages();

			app.Run();
        }
    }
}
