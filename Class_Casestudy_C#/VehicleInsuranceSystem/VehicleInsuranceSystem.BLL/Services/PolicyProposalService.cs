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
    public class PolicyProposalService : IPolicyProposalService
    {
        private readonly IGenericRepository<PolicyProposal> _proposalRepository;
        private readonly VehicleInsuranceDbContext _context;


        public PolicyProposalService(IGenericRepository<PolicyProposal> proposalRepository, VehicleInsuranceDbContext context)
        {
            _proposalRepository = proposalRepository;
            _context = context;
        }

        public async Task<IEnumerable<PolicyProposal>> GetAllProposalsAsync() => await _proposalRepository.GetAllAsync();

        // public async Task<PolicyProposal?> GetProposalByIdAsync(int id) => await _proposalRepository.GetByIdAsync(id);
        public async Task<PolicyProposal?> GetProposalByIdAsync(int PolicyProposalId) => await _proposalRepository.GetByIdAsync(PolicyProposalId);

        public async Task<PolicyProposal> SubmitProposalAsync(PolicyProposal proposal) => await _proposalRepository.AddAsync(proposal);

        public async Task<PolicyProposal> UpdateProposalAsync(PolicyProposal proposal) => await _proposalRepository.UpdateAsync(proposal);

        public async Task DeleteProposalAsync(int id) => await _proposalRepository.DeleteAsync(id);

        public async Task<List<PolicyProposal>> GetProposalsByUserIdAsync(int userId)
        {
            return await _context.PolicyProposals
                .Where(p => p.UserId == userId)
                .Include(p => p.PolicyAddOns)
                    .ThenInclude(pa => pa.AddOn)
                .Include(p => p.Vehicle)
                .Include(p => p.User)
                .Include(p => p.Policy)
                .ToListAsync();
        }

        public async Task<List<PolicyProposal>> GetAllProposalsDetailedAsync()
        {
            return await _context.PolicyProposals
                .Include(p => p.Vehicle)
                .Include(p => p.User)
                .Include(p => p.Policy)
                .Include(p => p.PolicyAddOns)
                    .ThenInclude(pa => pa.AddOn)
                .ToListAsync();
        }
    }

}
