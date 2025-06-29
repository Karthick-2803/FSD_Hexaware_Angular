using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsuranceSystem.DAL.Models;

namespace VehicleInsuranceSystem.BLL.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        //Task<Vehicle> GetVehicleByIdAsync(int id);
        Task<IEnumerable<Vehicle>> GetVehiclesByUserIdAsync(int userId);

        Task<Vehicle> AddVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(int id);
    }
}
