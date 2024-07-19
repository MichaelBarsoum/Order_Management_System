
using Order_Management_System.CORE.Helpers;
using Order_Management_System.CORE.Models.OrderAggregate;
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
        public OrderStatus Status { get; set; }
        public AddressAggregate Address { get; set; }
        public int? paymentMethodId { get; set; }
        public PaymentMethods paymentMethod { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [NotMapped]
        public IOrderState State { get; set; }

      





    }
}
