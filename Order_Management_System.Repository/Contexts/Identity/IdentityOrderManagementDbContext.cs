using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Repository.Contexts.Identity
{
    public class IdentityOrderManagementDbContext : IdentityDbContext<User>
    {
        public IdentityOrderManagementDbContext(DbContextOptions<IdentityOrderManagementDbContext> Options)
                                                :base(Options){}
    }
}
