using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleInsuranceSystem.BLL.Interfaces;
using VehicleInsuranceSystem.DAL.Data;
using VehicleInsuranceSystem.DAL.Models;
using VehicleInsuranceSystem.DAL.Repositories.Interfaces;

namespace VehicleInsuranceSystem.BLL.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IGenericRepository<Policy> _policyRepository;
        private readonly VehicleInsuranceDbContext _context;

        public PolicyService(IGenericRepository<Policy> policyRepository, VehicleInsuranceDbContext context)
        {
            _policyRepository = policyRepository;
            _context = context;
        }

        public async Task<IEnumerable<Policy>> GetAllPoliciesAsync() => await _policyRepository.GetAllAsync();

        //public async Task<Policy?> GetPolicyByIdAsync(int Policyid) => await _policyRepository.GetByIdAsync(Policyid);
        public async Task<Policy?> GetPolicyByIdAsync(int policyId)
        {
            return await _context.Policies
                .Include(p => p.PolicyProposal)
                    .ThenInclude(pp => pp.User)
                .Include(p => p.PolicyProposal)
                    .ThenInclude(pp => pp.Vehicle)
                .FirstOrDefaultAsync(p => p.PolicyId == policyId);
        }


        public async Task<Policy> AddPolicyAsync(Policy policy) => await _policyRepository.AddAsync(policy);

        public async Task<Policy> UpdatePolicyAsync(Policy policy) => await _policyRepository.UpdateAsync(policy);

        public async Task DeletePolicyAsync(int id) => await _policyRepository.DeleteAsync(id);
        public async Task<Policy> CreatePolicyAsync(Policy policy)
        {
            return await _policyRepository.AddAsync(policy);
        }
        public async Task<List<Policy>> GetPoliciesByUserIdAsync(int userId)
        {
            return await _context.Policies
            .Include(p => p.PolicyProposal)
            .ThenInclude(pp => pp.Vehicle)
            .Where(p => p.PolicyProposal.UserId == userId)
            .ToListAsync();
        }
    }

}
