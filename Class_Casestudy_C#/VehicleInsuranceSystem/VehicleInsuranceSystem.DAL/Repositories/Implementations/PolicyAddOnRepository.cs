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
    public class PolicyAddOnRepository : GenericRepository<PolicyAddOn>, IPolicyAddOnRepository
    {
        public PolicyAddOnRepository(VehicleInsuranceDbContext context) : base(context) { }

        public async Task<IEnumerable<PolicyAddOn>> GetByPolicyIdAsync(int policyProposalId)
        {
            return await _context.PolicyAddOns
                .Where(pa => pa.PolicyProposalId == policyProposalId)
                .ToListAsync();
        }
    }
}
