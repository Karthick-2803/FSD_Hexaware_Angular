using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInsuranceSystem.DAL.Data;
using VehicleInsuranceSystem.DAL.Models;
using VehicleInsuranceSystem.DAL.Repositories.Interfaces;

namespace VehicleInsuranceSystem.DAL.Repositories.Implementations
{
    public class AddOnRepository : GenericRepository<AddOn>, IAddOnRepository
    {
        public AddOnRepository(VehicleInsuranceDbContext context) : base(context) { }
    }
}
