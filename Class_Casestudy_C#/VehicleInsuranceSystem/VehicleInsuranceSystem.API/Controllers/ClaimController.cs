using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleInsuranceSystem.BLL.Interfaces;
using VehicleInsuranceSystem.BLL.Services;
using VehicleInsuranceSystem.DAL.Models;
using VehicleInsuranceSystem.API.Models.DTOs;
namespace VehicleInsuranceSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimService _claimService;

        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        [HttpPost("submit")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> SubmitClaim([FromBody] SubmitClaimDto dto)
        {
            var userId = GetLoggedInUserId(); // Fixing next
            if (userId == null)
                return Unauthorized();

            var claim = new VehicleInsuranceSystem.DAL.Models.Claim  // FIX: Fully qualified
            {
                PolicyId = dto.PolicyId,
                Reason = dto.Reason,
                //ClaimDocumentPath = dto.ClaimDocumentPath,
                Status = "Submitted",
                CreatedAt = DateTime.UtcNow
            };

            var created = await _claimService.SubmitClaimAsync(claim);
            return Ok(created);
        }



        [HttpGet("user")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetMyClaims()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var claims = await _claimService.GetClaimsByUserIdAsync(userId);
            return Ok(claims);
        }

        [HttpGet("officer")]
        [Authorize(Roles = "Officer")]
        public async Task<IActionResult> GetAllClaims()
        {
            var claims = await _claimService.GetAllClaimsAsync();
            return Ok(claims);
        }

        [HttpPut("update/{claimId}")]
        [Authorize(Roles = "Officer")]
        public async Task<IActionResult> UpdateStatus(int claimId, [FromQuery] string status, [FromQuery] string? comment)
        {
            var updatedClaim = await _claimService.UpdateClaimStatusAsync(claimId, status, comment);
            return Ok(updatedClaim);
        }

        private int? GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userId");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                return userId;

            return null;
        }
    }
}
