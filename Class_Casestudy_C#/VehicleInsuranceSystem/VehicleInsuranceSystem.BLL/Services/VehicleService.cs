using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsuranceSystem.BLL.Interfaces;
using VehicleInsuranceSystem.DAL.Models;
using VehicleInsuranceSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VehicleInsuranceSystem.BLL.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IGenericRepository<Vehicle> _vehicleRepository;

        public VehicleService(IGenericRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync() => await _vehicleRepository.GetAllAsync();

        //public async Task<Vehicle?> GetVehiclesByUserIdAsync(int id) => await _vehicleRepository.GetByIdAsync(id);
        //public async Task<IEnumerable<Vehicle>> GetVehiclesByUserIdAsync(int userId)
        //{
        //    var allVehicles = await _vehicleRepository.GetAllAsync();
        //    return allVehicles.Where(v => v.UserId == userId);
        //}
        public async Task<IEnumerable<Vehicle>> GetVehiclesByUserIdAsync(int userId)
        {
            return await _vehicleRepository.GetFilteredAsync(
                v => v.UserId == userId,
                v => v.User,                    // Eager load User
                v => v.PolicyProposal           // Eager load PolicyProposal
            );
        }


        public async Task<Vehicle> AddVehicleAsync(Vehicle vehicle) => await _vehicleRepository.AddAsync(vehicle);

        public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle) => await _vehicleRepository.UpdateAsync(vehicle);

        public async Task DeleteVehicleAsync(int id) => await _vehicleRepository.DeleteAsync(id);
    }

}
