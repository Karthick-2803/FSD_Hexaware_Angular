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
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // POST: api/vehicle/add
        [HttpPost("add")]
        public async Task<IActionResult> AddVehicle([FromBody] CreateVehicleDto dto)
        {
            var userId = GetLoggedInUserId();
            if (userId == null)
                return Unauthorized();

            var vehicle = new Vehicle
            {
                VehicleType = dto.VehicleType,
                RegistrationNumber = dto.RegistrationNumber,
                ManufacturingYear = dto.ManufacturingYear,
                ModelName = dto.ModelName,
                UserId = userId.Value
            };

            await _vehicleService.AddVehicleAsync(vehicle);
            return Ok("Vehicle added successfully.");
        }


        [HttpGet("my")]
        public async Task<IActionResult> GetMyVehicles()
        {
            var userId = GetLoggedInUserId();
            if (userId == null)
                return Unauthorized();

            var vehicles = await _vehicleService.GetVehiclesByUserIdAsync(userId.Value);
            return Ok(vehicles);
        }


        // Helper to extract userId from JWT token
        private int? GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userId");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                return userId;

            return null;
        }
    }
}
