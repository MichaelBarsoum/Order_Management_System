using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Repositories.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceDate { get; set; } 
        public decimal TotalAmount { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }

    }
}
