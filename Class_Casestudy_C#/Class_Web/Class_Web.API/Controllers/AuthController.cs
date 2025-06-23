using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Class_Web.DAL.Data;
using Class_Web.API.Models.Auth;
using Class_Web.DAL.Models;

namespace Class_Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Class_WebDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(Class_WebDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // ✅ Register a user
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = _context.Users.FirstOrDefault(u => u.EmailId == request.EmailId);
            if (existingUser != null)
                return BadRequest("User with this email already exists.");

            var user = new UserInfo
            {
                EmailId = request.EmailId,
                UserName = request.UserName,
                Password = request.Password,
                Role = request.Role
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully.");
        }

        // ✅ Login and return JWT token
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _context.Users.FirstOrDefault(u => u.EmailId == request.EmailId);

            if (user == null)
                return Unauthorized("Invalid email.");

            if (user.Password != request.Password)
                return Unauthorized("Invalid password.");

            var token = GenerateJwtToken(user);

            return Ok(new
            {
                Token = token,
                UserName = user.UserName,
                Role = user.Role
            });
        }

        // ✅ JWT Token generator
        private string GenerateJwtToken(UserInfo user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.EmailId),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:DurationInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
