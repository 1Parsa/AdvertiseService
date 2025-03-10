using AdvertiseService.Application.Common.DTOs;
using AdvertiseService.Domain.Entities;
using AdvertiseService.Infrastructure.Identity;
using AdvertiseService.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AdvertiseService.Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtService _jwtService;
        private readonly AuthService _authService;

        public AuthController(UserManager<ApplicationUser> userManager, JwtService jwtService, AuthService authService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return Unauthorized();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtService.GenerateToken(user);
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto request)
        {
            // تبدیل UserDto به مدل دامنه (User)
            var user = ApplicationUser.Create(request.Email, request.FullName, "User");
            user.SetPassword(request.Password); // در واقعیت باید هش شود

            // ثبت کاربر
            var result = await _authService.RegisterAsync(user, request.Password);

            return result ? Ok() : BadRequest();
        }








        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] UserDto request)
        //{
        //    var user =Domain.Entities.User.Create(request.Email, request.FullName, "User");
        //    user.SetPassword(request.Password); // در واقعیت باید هش شود
        //    var result = await _authService.RegisterAsync(user, request.Password);
        //    return result ? Ok() : BadRequest();
        //}


        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        //{
        //    var user = new User
        //    {
        //        UserName = request.Email,
        //        Email = request.Email,
        //        FullName = request.FullName
        //    };

        //    var result = await _userManager.CreateAsync(user, request.Password);

        //    if (!result.Succeeded)
        //    {
        //        return BadRequest(result.Errors);
        //    }

        //    return Ok();
        //}
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
