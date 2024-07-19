using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.CORE.Models.OrderAggregate
{
    // Refer To Product inside Order
    public class OrderItemAggregate
    {
        public OrderItemAggregate() { }
        public OrderItemAggregate(ProductItemOrdered productItemOrdered, int quantity, decimal price)
        {
            this.productItemOrdered = productItemOrdered;
            Quantity = quantity;
            Price = price;
        }

        public ProductItemOrdered productItemOrdered { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
