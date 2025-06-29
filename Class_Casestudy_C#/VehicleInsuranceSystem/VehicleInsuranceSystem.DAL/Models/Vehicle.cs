using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInsuranceSystem.DAL.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleType { get; set; } // Car, Bike, Camper Van
        public string RegistrationNumber { get; set; }
        public int ManufacturingYear { get; set; }
        public string ModelName { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        // Navigation property
        public PolicyProposal PolicyProposal { get; set; }
    }
}
