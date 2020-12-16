using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;
using WebApp.Models;

namespace WebApp.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //seed roles
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));    
        }
        public static async Task SeedSuperAdminAsync(UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new CustomUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                FirstName = "trung",
                LastName = "vu",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Trung@123");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }

            }
        }
    }
}
