using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsuranceSystem.BLL.Interfaces;
using VehicleInsuranceSystem.DAL.Data;
using VehicleInsuranceSystem.DAL.Models;
using VehicleInsuranceSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VehicleInsuranceSystem.BLL.Services
{
    public class ClaimService : IClaimService
    {
        private readonly VehicleInsuranceDbContext _context;

        public ClaimService(VehicleInsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<Claim> SubmitClaimAsync(Claim claim)
        {
            claim.CreatedAt = DateTime.UtcNow;
            claim.Status = "Initiated";

            _context.Claims.Add(claim);
            await _context.SaveChangesAsync();
            return claim;
        }

        public async Task<IEnumerable<Claim>> GetClaimsByUserIdAsync(int userId)
        {
            return await _context.Claims
                .Include(c => c.Policy)
                .Where(c => c.Policy.PolicyProposal.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Claim>> GetAllClaimsAsync()
        {
            return await _context.Claims
                .Include(c => c.Policy)
                .ThenInclude(p => p.PolicyProposal)
                .ThenInclude(pr => pr.User)
                .ToListAsync();
        }

        public async Task<Claim> UpdateClaimStatusAsync(int claimId, string status, string? comments)
        {
            var claim = await _context.Claims.FindAsync(claimId);
            if (claim != null)
            {
                claim.Status = status;
                claim.OfficerComments = comments;
                await _context.SaveChangesAsync();
            }
            return claim!;
        }
    }
}
