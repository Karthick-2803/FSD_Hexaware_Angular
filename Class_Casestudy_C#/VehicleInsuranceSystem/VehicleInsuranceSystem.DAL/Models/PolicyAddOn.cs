using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInsuranceSystem.DAL.Models
{
    public class PolicyAddOn
    {
        public int PolicyProposalId { get; set; }
        public PolicyProposal PolicyProposal { get; set; }

        public int AddOnId { get; set; }
        public AddOn AddOn { get; set; }
    }
}
