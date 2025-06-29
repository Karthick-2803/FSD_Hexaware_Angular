namespace VehicleInsuranceSystem.API.Models.DTOs
{
    public class SubmitProposalDto
    {
        public int VehicleId { get; set; }
        public List<int> AddOnIds { get; set; } 
    }
}
