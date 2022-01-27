using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Web
{
    public static class DatabaseSeeder
    {

        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            try
            {
                var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var _userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

                using (var context = new ApplicationDbContext(
                    serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
                {

                    if (await _roleManager.FindByNameAsync(AppConstant.AdminRole) == null)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(AppConstant.AdminRole));
                        var user = new IdentityUser { UserName = "bakareisrael@gmail.com", Email = "bakareisrael@gmail.com" };
                        var result = await _userManager.CreateAsync(user, "oluwaPelumi1*BOY*");
                        if (!result.Succeeded)
                            throw new Exception();
                        await _userManager.AddToRoleAsync(user, AppConstant.AdminRole);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
