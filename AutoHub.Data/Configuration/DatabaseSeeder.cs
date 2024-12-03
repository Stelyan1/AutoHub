using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoHub.Data.Configuration
{
    public class DatabaseSeeder
    {
        public static async Task SeedAsync(AutoHubDbContext context, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var role in roles) 
            {
                var roleExists = await roleManager.RoleExistsAsync(role);

                if (!roleExists)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task AssignAdminRole(AutoHubDbContext context, IServiceProvider serviceProvider) 
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string adminEmail = "admin@gmail.com";
            string adminUsername = "Admin";
            string adminPassword = "Admin123Ww";

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null) 
            {
                adminUser = new IdentityUser
                {
                    UserName = adminUsername,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var createUserResult = await userManager.CreateAsync(adminUser, adminPassword);

                if (!createUserResult.Succeeded) 
                {
                    throw new Exception($"Failed to create Admin user");
                }
            }

            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                var addToRoleResult = await userManager.AddToRoleAsync(adminUser, "Admin");

                if (!addToRoleResult.Succeeded)
                {
                    throw new Exception($"Failed to assign Admin role");
                }
            }
        }
    }
}
