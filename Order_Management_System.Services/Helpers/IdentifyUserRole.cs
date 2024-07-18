using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Services.Helpers
{
    public static class IdentifyUserRole
    {
        public static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in Enum.GetValues(typeof(UserRole)))
                if (!await roleManager.RoleExistsAsync(role.ToString()))
                    await roleManager.CreateAsync(new IdentityRole(role.ToString()));
        }
        public static async Task<bool> AssignRoleToUser(UserManager<User> userManager , string Email)
        {
            var user = await userManager.FindByEmailAsync(Email);
            if (user != null)
            {
                var result = await userManager.AddToRoleAsync(user, user.Roles.ToString());
                return result.Succeeded;
            }
            return false;

        }
    }
}
