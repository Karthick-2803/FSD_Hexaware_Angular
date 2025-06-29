using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsuranceSystem.DAL.Models;

namespace VehicleInsuranceSystem.BLL.Interfaces
{
        public interface IClaimService
        {
            Task<Claim> SubmitClaimAsync(Claim claim);
            Task<IEnumerable<Claim>> GetClaimsByUserIdAsync(int userId);
            Task<IEnumerable<Claim>> GetAllClaimsAsync(); // For officer
            Task<Claim> UpdateClaimStatusAsync(int claimId, string status, string? comments);
        }
}
