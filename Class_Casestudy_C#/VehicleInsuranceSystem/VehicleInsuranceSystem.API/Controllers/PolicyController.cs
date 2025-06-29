using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleInsuranceSystem.BLL.Interfaces;
using VehicleInsuranceSystem.DAL.Models;
namespace VehicleInsuranceSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Customer")]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;
        private readonly IDocumentService _documentService;

        public PolicyController(IPolicyService policyService, IDocumentService documentService)
        {
            _policyService = policyService;
            _documentService = documentService;
        }

        // GET: api/policy/my-policies
        [HttpGet("my-policies")]
        public async Task<IActionResult> GetMyPolicies()
        {
            var userId = GetLoggedInUserId();
            if (userId == null)
                return Unauthorized();

            var policies = await _policyService.GetPoliciesByUserIdAsync(userId.Value);
            return Ok(policies);
        }

        // GET: api/policy/download/{policyId}
        [HttpGet("download/{policyId}")]
        public async Task<IActionResult> DownloadPolicyDocument(int policyId)
        {
            var userId = GetLoggedInUserId();
            if (userId == null)
                return Unauthorized();

            var policy = await _policyService.GetPolicyByIdAsync(policyId);
            if (policy == null || policy.PolicyProposal == null || policy.PolicyProposal.UserId != userId)
                return NotFound("Policy not found or unauthorized");

            var pdfBytes = _documentService.GeneratePolicyDocument(policy);

            return File(pdfBytes, "application/pdf", $"Policy_{policyId}.pdf");
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
