using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using HumanResourcesDepartment.Models;

namespace HumanResourcesDepartment
{
    public class IdentityInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("HR-Manager") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("HR-Manager"));
            }
            if (await userManager.FindByNameAsync("admin") == null)
            {
                User admin = new User { UserName = "admin", FirstName = "Денис", SecondName = "Мишота" };

                IdentityResult result = await userManager.CreateAsync(admin, "admin");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }

            }
        }
    }
}

