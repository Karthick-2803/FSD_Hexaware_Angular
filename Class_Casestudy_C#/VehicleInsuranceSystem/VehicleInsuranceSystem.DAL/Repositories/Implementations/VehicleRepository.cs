using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsuranceSystem.DAL.Data;
using VehicleInsuranceSystem.DAL.Models;
using VehicleInsuranceSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VehicleInsuranceSystem.DAL.Repositories.Implementations
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        private readonly VehicleInsuranceDbContext _context;

        public VehicleRepository(VehicleInsuranceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByUserIdAsync(int userId)
        {
            return await _context.Vehicles
                .Where(v => v.UserId == userId)
                .ToListAsync();
        }
    }
}
