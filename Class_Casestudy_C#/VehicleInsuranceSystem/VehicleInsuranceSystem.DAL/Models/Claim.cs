using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInsuranceSystem.DAL.Models
{
    public class Claim
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PolicyId { get; set; }

        [ForeignKey("PolicyId")]
        public Policy Policy { get; set; }

        [Required]
        public string Reason { get; set; }

        public string? ClaimDocumentPath { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string Status { get; set; } // Initiated, Under Review, Approved, Rejected

        public string? OfficerComments { get; set; }
    }
}
