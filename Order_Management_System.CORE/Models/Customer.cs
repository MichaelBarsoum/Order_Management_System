using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Repositories.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; 
        public string Email { get; set; } = null!;
        public ICollection<Order?> Orders { get; set; } = new List<Order?>();
    }
}
