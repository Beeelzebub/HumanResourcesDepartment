using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using HumanResourcesDepartment.Models;

namespace HumanResourcesDepartment
{
    public class RoleInitializer
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
                User admin = new User { UserName = "admin", FirstName = "Денис", Surname = "Мишота", Patronymic = "Денисович" };
                IdentityResult result = await userManager.CreateAsync(admin, "admin");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
            if (await userManager.FindByNameAsync("hr") == null)
            {
                User hr = new User { UserName = "hr", FirstName = "Иван", Surname = "Иванов", Patronymic = "Иванович" };

                IdentityResult result = await userManager.CreateAsync(hr, "hr");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(hr, "HR-Manager");
                }
            }
        }
    }
}