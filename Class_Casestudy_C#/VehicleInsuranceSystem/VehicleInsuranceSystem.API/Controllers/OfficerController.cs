using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using VehicleInsuranceSystem.API.Models.DTOs;
using VehicleInsuranceSystem.BLL.Interfaces;
using VehicleInsuranceSystem.DAL.Models;
using Microsoft.AspNetCore.Authorization;

namespace VehicleInsuranceSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Officer")]
    public class OfficerController : ControllerBase
    {
        private readonly IPolicyProposalService _proposalService;

        public OfficerController(IPolicyProposalService proposalService)
        {
            _proposalService = proposalService;
        }

        // GET: api/officer/proposals
        [HttpGet("proposals")]
        public async Task<IActionResult> GetAllProposals()
        {
            var proposals = await _proposalService.GetAllProposalsDetailedAsync();
            return Ok(proposals);
        }

        // PUT: api/officer/proposal/request-docs/{id}
        [HttpPut("proposal/request-docs/{id}")]
        public async Task<IActionResult> RequestDocuments(int id)
        {
            var proposal = await _proposalService.GetProposalByIdAsync(id);
            if (proposal == null)
                return NotFound("Proposal not found");

            proposal.Status = "Documents Requested";
            await _proposalService.UpdateProposalAsync(proposal);

            return Ok("Document request noted.");
        }

        // PUT: api/officer/proposal/approve/{id}
        [HttpPut("proposal/approve/{id}")]
        public async Task<IActionResult> ApproveProposal(int id)
        {
            var proposal = await _proposalService.GetProposalByIdAsync(id);
            if (proposal == null)
                return NotFound("Proposal not found");

            // Business logic to calculate quote
            decimal basePremium = 5000;
            //decimal addonCharge = proposal.PolicyAddOns?.Split(',').Length * 1000 ?? 0;
            decimal addonCharge = proposal.SelectedAddOnsCsv != null
                           ? proposal.SelectedAddOnsCsv.Split(',').Length * 1000
                           : 0;

            proposal.PremiumAmount = basePremium + addonCharge;

            proposal.Status = "Quote Generated";
            proposal.QuoteGeneratedDate = DateTime.Now;

            await _proposalService.UpdateProposalAsync(proposal);

            return Ok(new
            {
                message = "Quote generated successfully",
                premium = proposal.PremiumAmount
            });
        }

        // PUT: api/officer/proposal/reject/{id}
        [HttpPut("proposal/reject/{id}")]
        public async Task<IActionResult> RejectProposal(int id)
        {
            var proposal = await _proposalService.GetProposalByIdAsync(id);
            if (proposal == null)
                return NotFound("Proposal not found");

            proposal.Status = "Rejected";
            await _proposalService.UpdateProposalAsync(proposal);

            return Ok("Proposal rejected.");
        }
    }
}
