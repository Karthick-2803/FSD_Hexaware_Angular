using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsuranceSystem.DAL.Models;

namespace VehicleInsuranceSystem.BLL.Interfaces
{
    public interface IPolicyProposalService
    {
        Task<IEnumerable<PolicyProposal>> GetAllProposalsAsync();
        Task<PolicyProposal> GetProposalByIdAsync(int PolicyProposalId);
        Task<PolicyProposal> SubmitProposalAsync(PolicyProposal proposal);
        Task<PolicyProposal> UpdateProposalAsync(PolicyProposal proposal);
        Task DeleteProposalAsync(int id);
        Task<List<PolicyProposal>> GetProposalsByUserIdAsync(int userId);
        Task<List<PolicyProposal>> GetAllProposalsDetailedAsync();
    }
}
