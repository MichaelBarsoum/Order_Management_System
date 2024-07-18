﻿using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.API.DTOs.User
{
    public class RegisterDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
