using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInsuranceSystem.DAL.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string AadhaarNumber { get; set; }
        public string PANNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // "Customer" or "Officer"

        public ICollection<PolicyProposal> PolicyProposals { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }

    }
}
