﻿namespace VehicleInsuranceSystem.API.Models.DTOs
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
    }
}
