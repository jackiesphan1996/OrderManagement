using Microsoft.AspNetCore.Identity;
using OrderManagement.Application.Enums;
using OrderManagement.Infrastructure.Identity.Models;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Waitor.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Cooker.ToString()));
        }
    }
}
