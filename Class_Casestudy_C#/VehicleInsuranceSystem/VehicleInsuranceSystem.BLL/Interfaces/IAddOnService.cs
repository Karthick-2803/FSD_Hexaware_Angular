using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsuranceSystem.DAL.Models;

namespace VehicleInsuranceSystem.BLL.Interfaces
{
    public interface IAddOnService
    {
        Task<IEnumerable<AddOn>> GetAllAddOnsAsync();
        Task<AddOn?> GetAddOnByIdAsync(int id);
        Task<AddOn> AddAddOnAsync(AddOn addon);
        Task<AddOn> UpdateAddOnAsync(AddOn addon);
        Task DeleteAddOnAsync(int id);
    }
}
