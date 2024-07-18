using Microsoft.AspNetCore.Identity;
using Order_Management_System.Repositories.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Repository.DataSeed.IdentitySeed
{
    public static class DefaultRoles
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if(!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(UserRole.Admin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(UserRole.Customer.ToString()));
            }
            
        }
    }
}
