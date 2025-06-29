using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsuranceSystem.DAL.Models;

namespace VehicleInsuranceSystem.BLL.Interfaces
{
    public interface IPolicyAddOnService
    {
        Task<IEnumerable<PolicyAddOn>> GetAllPolicyAddOnsAsync();
        Task<PolicyAddOn> AddPolicyAddOnAsync(PolicyAddOn policyAddOn);
    }
}
