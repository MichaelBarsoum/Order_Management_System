using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.CORE.Models.OrderAggregate
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered() { }
        public ProductItemOrdered(int id, int productID, string productName)
        {
            Id = id;
            ProductID = productID;
            ProductName = productName;
        }

        public int Id { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }

    }
}
