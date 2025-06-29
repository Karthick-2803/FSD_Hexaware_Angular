namespace VehicleInsuranceSystem.API.Models.DTOs
{
    public class CreateVehicleDto
    {
        public string VehicleType { get; set; }
        public string RegistrationNumber { get; set; }
        public int ManufacturingYear { get; set; }
        public string ModelName { get; set; }
    }
}
