using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.API.DTOs.Customer
{
    public class CustomerDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
