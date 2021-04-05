using System;
using System.Threading.Tasks;
using ElectronicStore.Models;
using Microsoft.AspNetCore.Identity;

namespace ElectronicStore.Services
{
    public class RoleInitializer
    {
        public enum Roles
        {
            Admin,
            Client
        }
        public static async Task Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            
            var roles = new[] { Roles.Admin,Roles.Client};
            foreach (var value in roles)
            {
                string role = Convert.ToString(value);
                if (await roleManager.FindByNameAsync(role) is null)
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            string adminEmail = "admin@admin.com";
            string adminPassword = "Admin123";
            if (await userManager.FindByEmailAsync(adminEmail) is null)
            {
                User admin = new User
                {
                    Id = "1",
                    Email = adminEmail,
                    EmailConfirmed = true,
                    UserName = "admin",
                    Name = "Admin",
                    Surname = string.Empty
                };
                var result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin,Convert.ToString(Roles.Admin));
            }

        }
    }
}