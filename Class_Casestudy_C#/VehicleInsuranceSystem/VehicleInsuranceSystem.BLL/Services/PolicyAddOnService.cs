using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsuranceSystem.BLL.Interfaces;
using VehicleInsuranceSystem.DAL.Models;
using VehicleInsuranceSystem.DAL.Repositories.Interfaces;
namespace VehicleInsuranceSystem.BLL.Services
{
    public class PolicyAddOnService : IPolicyAddOnService
    {
        private readonly IGenericRepository<PolicyAddOn> _policyAddOnRepository;

        public PolicyAddOnService(IGenericRepository<PolicyAddOn> policyAddOnRepository)
        {
            _policyAddOnRepository = policyAddOnRepository;
        }

        public async Task<IEnumerable<PolicyAddOn>> GetAllPolicyAddOnsAsync()
        {
            return await _policyAddOnRepository.GetAllAsync();
        }

        public async Task<PolicyAddOn> AddPolicyAddOnAsync(PolicyAddOn policyAddOn)
        {
            return await _policyAddOnRepository.AddAsync(policyAddOn);
        }
    }

}
