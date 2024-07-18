using Microsoft.AspNetCore.Identity;
using Order_Management_System.Repositories.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Repositories.Models
{
    public class User : IdentityUser
    {
        public UserRole Roles { get; set; }
    }
}
