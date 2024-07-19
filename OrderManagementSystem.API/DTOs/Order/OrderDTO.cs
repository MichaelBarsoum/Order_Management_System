using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repositories.Models;
using Order_Management_System.Repository.OrderState;
using OrderManagementSystem.API.DTOs.Product;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementSystem.API.DTOs.Order
{
    public class OrderDTO
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        //  order item class
        public int Quantity { get; set; }
        // product inside order items class
        public decimal ItemPrice { get; } 
        public string PaymentMethod { get; set; }
        public decimal TotalItemsAmount => Quantity * ItemPrice;

    }
}
