
using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repository.OrderState;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order_Management_System.Repositories.Models
{
    public class Order
    {
        public Order()
        {
            State = new OrderProcessingState(this);
        }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now.Date;
        public decimal TotalAmount { get; set; }
        public string PayMethod { get; set; } = null!;
        public OrderStatus Status { get; set; } 
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        [NotMapped]
        public IOrderState State { get; set; }
    }
}
