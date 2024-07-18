using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.API.DTOs.Product
{
    public class ProductDTO
    {
        [Required]
        [MaxLength(100,ErrorMessage = "Maximum length is 100 Chars")]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

    }
}
