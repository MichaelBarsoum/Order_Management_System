using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repositories.Models;
using OrderManagementSystem.API.DTOs.Product;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.API.DTOs.Order
{
    public class OrderDTO
    {
        public string OrderDate { get; set; }
        public ProductDTO product { get; set; }
        public string PaymentMethod { get; set; }

    }
}
