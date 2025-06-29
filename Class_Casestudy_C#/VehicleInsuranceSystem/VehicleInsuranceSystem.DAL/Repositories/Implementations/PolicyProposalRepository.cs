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
    public class PolicyProposalRepository : GenericRepository<PolicyProposal>, IPolicyProposalRepository
    {
        public PolicyProposalRepository(VehicleInsuranceDbContext context) : base(context) { }

        public async Task<IEnumerable<PolicyProposal>> GetProposalsByUserIdAsync(int userId)
        {
            return await _context.PolicyProposals
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }
    }
}
