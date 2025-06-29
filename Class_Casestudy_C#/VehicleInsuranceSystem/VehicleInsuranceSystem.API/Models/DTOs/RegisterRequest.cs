namespace VehicleInsuranceSystem.API.Models.DTOs
{
    public class RegisterRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AadhaarNumber { get; set; }
        public string PAN { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
