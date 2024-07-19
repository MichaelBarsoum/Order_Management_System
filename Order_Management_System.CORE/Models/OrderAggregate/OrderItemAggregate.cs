using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.CORE.Models.OrderAggregate
{
    public class OrderItemAggregate
    {
        public OrderItemAggregate() { }
        public OrderItemAggregate(ProductItemOrdered productItem, int quantity, decimal price)
        {
            this.productItem = productItem;
            Quantity = quantity;
            Price = price;
        }
        public ProductItemOrdered productItem { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
