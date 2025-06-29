namespace VehicleInsuranceSystem.API.Models.DTOs
{
    public class SubmitClaimDto
    {
        public int PolicyId { get; set; }
        public string Reason { get; set; }
        //public string? ClaimDocumentPath { get; set; }
    }
}
