using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repositories.Models;
using OrderManagementSystem.API.DTOs.Order;

namespace OrderManagementSystem.API.DTOs.Customer
{
    public class CustomerOrderToReturnDTO
    {
        public int CustomerId { get; set; } 
        public string Name { get; set; }
        public ICollection<OrderDTO> orders { get; set; } = new List<OrderDTO>();
    }
}
