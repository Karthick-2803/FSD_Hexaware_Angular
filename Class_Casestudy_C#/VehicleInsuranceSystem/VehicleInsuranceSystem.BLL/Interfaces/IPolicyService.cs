using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsuranceSystem.DAL.Models;

namespace VehicleInsuranceSystem.BLL.Interfaces
{
    public interface IPolicyService
    {
        Task<IEnumerable<Policy>> GetAllPoliciesAsync();
        Task<Policy> GetPolicyByIdAsync(int Policyid);
        Task<Policy> AddPolicyAsync(Policy policy);
        Task<Policy> UpdatePolicyAsync(Policy policy);
        Task DeletePolicyAsync(int id);
        Task<Policy> CreatePolicyAsync(Policy policy);
        Task<List<Policy>> GetPoliciesByUserIdAsync(int userId);
    }
}
