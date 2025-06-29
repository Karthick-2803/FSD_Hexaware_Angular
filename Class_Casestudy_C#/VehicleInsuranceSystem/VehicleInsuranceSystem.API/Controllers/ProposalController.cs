using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleInsuranceSystem.DAL.Models;
using VehicleInsuranceSystem.BLL.Interfaces;
using VehicleInsuranceSystem.API.Models.DTOs;

namespace VehicleInsuranceSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Customer")]
    public class ProposalController : ControllerBase
    {
        private readonly IPolicyProposalService _proposalService;

        public ProposalController(IPolicyProposalService proposalService)
        {
            _proposalService = proposalService;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitProposal([FromBody] SubmitProposalDto dto)
        {
            var userId = GetLoggedInUserId();
            if (userId == null)
                return Unauthorized();

            var proposal = new PolicyProposal
            {
                UserId = userId.Value,
                VehicleId = dto.VehicleId,
                Status = "Proposal Submitted",
                SubmittedOn = DateTime.Now,
                IsPaid = false,
                PolicyAddOns = dto.AddOnIds.Select(id => new PolicyAddOn
                {
                    AddOnId = id
                }).ToList()
            };

            await _proposalService.SubmitProposalAsync(proposal);
            return Ok("Proposal submitted successfully.");
        }

        // GET: api/proposal/my
        [HttpGet("my")]
        public async Task<IActionResult> GetMyProposals()
        {
            var userId = GetLoggedInUserId();
            if (userId == null)
                return Unauthorized();

            var proposals = await _proposalService.GetProposalsByUserIdAsync(userId.Value);
            return Ok(proposals);
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
