namespace VehicleInsuranceSystem.OfficerUI.Models
{
    public class ProposalViewModel
    {
        public int PolicyProposalId { get; set; }
        public string FullName { get; set; }
        public string VehicleType { get; set; }
        public string RegistrationNumber { get; set; }
        public string Status { get; set; }
        public decimal PremiumAmount { get; set; }
    }

}
