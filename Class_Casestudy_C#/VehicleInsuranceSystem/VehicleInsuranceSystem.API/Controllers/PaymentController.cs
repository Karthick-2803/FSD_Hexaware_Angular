using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleInsuranceSystem.BLL.Interfaces;
using VehicleInsuranceSystem.BLL.Services;
using VehicleInsuranceSystem.DAL.Models;

namespace VehicleInsuranceSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Customer")]
    public class PaymentController : ControllerBase
    {
        private readonly IPolicyProposalService _proposalService;
        private readonly IPolicyService _policyService;
        private readonly IEmailService _emailService;
        private readonly IDocumentService _documentService;

        public PaymentController(IPolicyProposalService proposalService,
                                 IPolicyService policyService,
                                 IEmailService emailService,
                                 IDocumentService documentService) // Inject DocumentService
        {
            _proposalService = proposalService;
            _policyService = policyService;
            _emailService = emailService;
            _documentService = documentService;
        }

        // POST: api/payment/pay/{proposalId}
        [HttpPost("pay/{PolicyproposalId}")]
        public async Task<IActionResult> PayPremium(int PolicyproposalId)
        {
            var userId = GetLoggedInUserId();
            if (userId == null)
                return Unauthorized();

            var proposal = await _proposalService.GetProposalByIdAsync(PolicyproposalId);
            if (proposal == null || proposal.UserId != userId)
                return BadRequest("Invalid proposal");

            if (proposal.Status != "Quote Generated")
                return BadRequest("Proposal must be in 'Quote Generated' state to make payment.");

            // Update proposal status
            proposal.Status = "Active";
            proposal.SubmittedOn = DateTime.Now;
            await _proposalService.UpdateProposalAsync(proposal);

            // Create policy
            var policy = new Policy
            {
                PolicyProposalId = proposal.PolicyProposalId,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1),
                Status = "Active",
                PremiumAmount = proposal.PremiumAmount
            };

            await _policyService.CreatePolicyAsync(policy);

            // 🔽 Fetch the newly created policy with full data (optional, but good for consistency)
            var fullPolicy = await _policyService.GetPolicyByIdAsync(policy.PolicyId);

            // Generate PDF document
            var pdfBytes = _documentService.GeneratePolicyDocument(fullPolicy);

            // 🔽 Save the document path (you can update to store actual file path if saving to disk)
            fullPolicy.DocumentUrl = $"Policy_{policy.PolicyId}.pdf";
            await _policyService.UpdatePolicyAsync(fullPolicy);

            // Send Email
            await _emailService.SendEmailWithAttachmentAsync(
                proposal.User.Email,
                "Policy Activated - Vehicle Insurance",
                $"Dear {proposal.User.FullName},\n\n" +
                $"Your payment was successful and your policy #{policy.PolicyId} is now active.\n" +
                $"Please find attached your policy document.\n\nRegards,\nVehicle Insurance Team",
                pdfBytes,
                fullPolicy.DocumentUrl
            );

            return Ok(new
            {
                message = "Payment successful. Policy activated and emailed.",
                policyId = fullPolicy.PolicyId,
                documentUrl = fullPolicy.DocumentUrl
            });
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