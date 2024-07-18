using Order_Management_System.Repositories.Models;

namespace Order_Management_System.Repositories.Helpers
{
    public class PaymentMethods
    {
        public int Id { get; set; }
        public string PaymentName { get; set; } = null!;
        public int orderId { get; set; }
        public ICollection<Order> orders { get; set; } = new List<Order>();

    }
}
