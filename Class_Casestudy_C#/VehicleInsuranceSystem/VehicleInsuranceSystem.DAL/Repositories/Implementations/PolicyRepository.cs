using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleInsuranceSystem.DAL.Data;
using VehicleInsuranceSystem.DAL.Models;
using VehicleInsuranceSystem.DAL.Repositories.Interfaces;

namespace VehicleInsuranceSystem.DAL.Repositories.Implementations
{
    public class PolicyRepository : GenericRepository<Policy>, IPolicyRepository
    {
        public PolicyRepository(VehicleInsuranceDbContext context) : base(context) { }

        public async Task<Policy> GetPolicyByProposalIdAsync(int proposalId)
        {
            return await _context.Policies
                .FirstOrDefaultAsync(p => p.PolicyProposalId == proposalId);
        }
    }
}
