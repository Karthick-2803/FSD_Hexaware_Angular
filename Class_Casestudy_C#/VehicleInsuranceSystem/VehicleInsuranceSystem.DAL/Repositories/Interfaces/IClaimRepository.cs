using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsuranceSystem.DAL.Models;

namespace VehicleInsuranceSystem.DAL.Repositories.Interfaces
{
    public interface IClaimRepository : IGenericRepository<Claim>
    {
        Task<IEnumerable<Claim>> GetClaimsByPolicyIdAsync(int policyId);
    }
}
