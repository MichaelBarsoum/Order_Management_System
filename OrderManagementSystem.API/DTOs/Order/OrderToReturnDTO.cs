using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repositories.Models;

namespace OrderManagementSystem.API.DTOs.Order
{
    public class OrderToReturnDTO
    {
        // Expand OrderItem list
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

        // From orderDTO
        public DateTime OrderDate { get; set; } = DateTime.Now.Date;
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Processing;

        








    }
}
