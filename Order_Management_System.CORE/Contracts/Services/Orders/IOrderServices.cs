using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.CORE.Contracts.Services.Orders
{
    public interface IOrderServices
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> UpdateOrderStatusAsync(int orderId, string? status);
    }
}
