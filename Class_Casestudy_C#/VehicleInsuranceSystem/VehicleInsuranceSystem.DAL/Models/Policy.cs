using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInsuranceSystem.DAL.Models
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public int PolicyProposalId { get; set; }
        public PolicyProposal PolicyProposal { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? DocumentUrl { get; set; }
        public decimal PremiumAmount { get; set; }  
        public string Status { get; set; }          
    }
}
