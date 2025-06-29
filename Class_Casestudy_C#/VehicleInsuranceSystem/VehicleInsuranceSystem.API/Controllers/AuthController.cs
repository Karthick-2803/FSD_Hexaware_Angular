using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using VehicleInsuranceSystem.API.Models.DTOs;
using VehicleInsuranceSystem.BLL.Interfaces;
using VehicleInsuranceSystem.DAL.Models;
namespace VehicleInsuranceSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var existingUser = await _userService.GetByEmailAsync(request.Email);
            if (existingUser != null)
                return BadRequest("Email already registered.");

            var user = new User
            {
                FullName = request.Name,
                Address = request.Address,
                DOB = request.DateOfBirth,
                AadhaarNumber = request.AadhaarNumber,
                PANNumber = request.PAN,
                Email = request.Email,
                PasswordHash = request.Password, // In production, hash this!
                Role = request.Role
            };

            await _userService.AddUserAsync(user);
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userService.GetByEmailAsync(request.Email);
            if (user == null || user.PasswordHash != request.Password)
                return Unauthorized("Invalid credentials.");

            var token = GenerateJwtToken(user);
            var response = new LoginResponse
            {
                Token = token,
                Role = user.Role,
                UserName = user.FullName
            };

            return Ok(response);
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new System.Security.Claims.Claim(JwtRegisteredClaimNames.Sub, user.Email),
        new System.Security.Claims.Claim("userId", user.UserId.ToString()),
        new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, user.Role)
    };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpireMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
