using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsuranceSystem.DAL.Models;

namespace VehicleInsuranceSystem.DAL.Repositories.Interfaces
{
    public interface IPolicyRepository : IGenericRepository<Policy>
    {
        Task<Policy> GetPolicyByProposalIdAsync(int proposalId);
    }
}
