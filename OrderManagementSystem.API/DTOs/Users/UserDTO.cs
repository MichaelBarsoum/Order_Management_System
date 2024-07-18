using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.API.DTOs.User
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
