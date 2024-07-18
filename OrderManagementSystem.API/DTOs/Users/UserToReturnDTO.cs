using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.API.DTOs.Users
{
    public class UserToReturnDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
