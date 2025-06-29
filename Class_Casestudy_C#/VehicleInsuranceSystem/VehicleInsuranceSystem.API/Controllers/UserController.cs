using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleInsuranceSystem.API.Models.DTOs;
using VehicleInsuranceSystem.BLL.Interfaces;
using VehicleInsuranceSystem.DAL.Models;

namespace VehicleInsuranceSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Customer")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user/profile
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = GetLoggedInUserId();
            if (userId == null)
                return Unauthorized();

            var user = await _userService.GetUserByIdAsync(userId.Value);
            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        // PUT: api/user/profile
        // PUT: api/user/profile
        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UserProfileUpdateDto dto)
        {
            var userId = GetLoggedInUserId();
            if (userId == null)
                return Unauthorized();

            var existingUser = await _userService.GetUserByIdAsync(userId.Value);
            if (existingUser == null)
                return NotFound("User not found");

            // Only update allowed fields
            existingUser.FullName = dto.FullName;
            existingUser.Address = dto.Address;
            existingUser.AadhaarNumber = dto.AadhaarNumber;
            existingUser.PANNumber = dto.PANNumber;

            await _userService.UpdateUserAsync(existingUser);
            return Ok("Profile updated successfully");
        }


        // Helper method to get userId from JWT
        private int? GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userId");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                return userId;

            return null;
        }
    }

}
