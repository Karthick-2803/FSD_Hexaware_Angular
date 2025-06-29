using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleInsuranceSystem.DAL.Data;
using VehicleInsuranceSystem.DAL.Repositories.Interfaces;
using VehicleInsuranceSystem.DAL.Models;

namespace VehicleInsuranceSystem.DAL.Repositories.Implementations
{
    public class ClaimRepository : GenericRepository<Claim>, IClaimRepository
    {
        public ClaimRepository(VehicleInsuranceDbContext context) : base(context) { }

        public async Task<IEnumerable<Claim>> GetClaimsByPolicyIdAsync(int policyId)
        {
            return await _context.Claims
                .Where(c => c.PolicyId == policyId)
                .ToListAsync();
        }
    }
}
