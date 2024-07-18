using Microsoft.AspNetCore.Identity;
using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repositories.Models;


namespace Order_Management_System.Repository.DataSeed.IdentitySeed
{
    public static class DefaultUsers
    {
        public static async Task SeedAdminRoleAsync(UserManager<User> userManager)
        {
            if(!userManager.Users.Any())
            {
                var defaultUser = new User()
                {
                    UserName = "Admin@domain.com",
                    Email = "Admin@domain.com",
                    EmailConfirmed = true,
                };
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "P@$$w0rd");
                    await userManager.AddToRoleAsync(defaultUser, UserRole.Admin.ToString());
                }
            }
        }

        public static async Task SeedCustomerRoleAsync(UserManager<User> userManager)
        {
            if(!userManager.Users.Any())
            {
                var defaultUser = new User()
                {
                    UserName = "Customer@domain.com",
                    Email = "Customer@domain.com",
                    EmailConfirmed = true,
                };
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "P@$$w0rd");
                    await userManager.AddToRoleAsync(defaultUser, UserRole.Customer.ToString());
                }
            }
        }



    }
}
