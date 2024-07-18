using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Order_Management_System.CORE.Contracts.Services.Auth;
using Order_Management_System.Repositories.Helpers;
using Order_Management_System.Repositories.Models;
using Order_Management_System.Services.Helpers;
using OrderManagementSystem.API.DTOs.User;
using OrderManagementSystem.API.DTOs.Users;
using OrderManagementSystem.API.Errors;

namespace OrderManagementSystem.API.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthService _authService;

        public AccountsController(UserManager<User> userManager, SignInManager<User> signInManager,
                                  IAuthService authService )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
        }
        // Register
        [HttpPost("Register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO model)
        {
            var user = new User()
            {
                UserName = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };
            var Result = await _userManager.CreateAsync(user, model.Password);
            if (!Result.Succeeded) return BadRequest(new ApiErrorResponse(StatusCodes.Status400BadRequest));
            var ReturnedUser = new UserDTO()
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = await _authService.GenerateTokenAsync(user,_userManager)
            };
            return Ok(ReturnedUser);
        }

        // Login => POST /api/users/login - Authenticate a user and return a JWT token
        [HttpPost("Login")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDTO>> Login(UserToReturnDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null) return Unauthorized(new ApiErrorResponse(StatusCodes.Status401Unauthorized, "InValid Email!"));
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) return Unauthorized(new ApiErrorResponse(StatusCodes.Status401Unauthorized));
            var ReturnedUser = new UserDTO()
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = await _authService.GenerateTokenAsync(user, _userManager)
            };
            return Ok(ReturnedUser);
        }
    }
}
