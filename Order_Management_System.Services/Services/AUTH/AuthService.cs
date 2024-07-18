using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Order_Management_System.CORE.Contracts.Services.Auth;
using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repositories.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Services.Services.AUTH
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GenerateTokenAsync(User user , UserManager<User> userManager)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.GivenName, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role,user.Roles.ToString())
            };
            var AuthKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var token = new JwtSecurityToken
                (
                     issuer: _configuration["JWT:Issuer"],
                     audience: _configuration["JWT:Audience"],
                     expires: DateTime.Now.AddDays(double.Parse(_configuration["JWT:DurationToExpireInDays"])),
                     claims: claims,
                     signingCredentials: new SigningCredentials(AuthKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
