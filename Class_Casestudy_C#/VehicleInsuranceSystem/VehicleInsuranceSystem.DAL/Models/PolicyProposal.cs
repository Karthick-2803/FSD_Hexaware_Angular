using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInsuranceSystem.DAL.Models
{
    public class PolicyProposal
    {
        public int PolicyProposalId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public DateTime SubmittedOn { get; set; }
        public string Status { get; set; } // proposal submitted, quote generated, active, expired

        public decimal PremiumAmount { get; set; }
        public bool IsPaid { get; set; }

        public DateTime? QuoteGeneratedDate { get; set; }  

        public string? SelectedAddOnsCsv { get; set; }     

        public ICollection<PolicyAddOn> PolicyAddOns { get; set; }
        public Policy Policy { get; set; }

        //public string? UploadedDocumentUrls { get; set; } // CSV of uploaded file URLs

        //public Claim Claim { get; set; }
    }
}
