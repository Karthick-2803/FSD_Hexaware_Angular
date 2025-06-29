using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInsuranceSystem.DAL.Models
{
    public class AddOn
    {
        public int AddOnId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public ICollection<PolicyAddOn> PolicyAddOns { get; set; }
    }
}
