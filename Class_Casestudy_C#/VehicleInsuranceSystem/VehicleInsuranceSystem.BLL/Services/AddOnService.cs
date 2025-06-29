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
    public class AddOnService : IAddOnService
    {
        private readonly IGenericRepository<AddOn> _addonRepository;

        public AddOnService(IGenericRepository<AddOn> addonRepository)
        {
            _addonRepository = addonRepository;
        }

        public async Task<IEnumerable<AddOn>> GetAllAddOnsAsync() => await _addonRepository.GetAllAsync();

        public async Task<AddOn?> GetAddOnByIdAsync(int id) => await _addonRepository.GetByIdAsync(id);

        public async Task<AddOn> AddAddOnAsync(AddOn addon) => await _addonRepository.AddAsync(addon);

        public async Task<AddOn> UpdateAddOnAsync(AddOn addon) => await _addonRepository.UpdateAsync(addon);

        public async Task DeleteAddOnAsync(int id) => await _addonRepository.DeleteAsync(id);
    }

}
