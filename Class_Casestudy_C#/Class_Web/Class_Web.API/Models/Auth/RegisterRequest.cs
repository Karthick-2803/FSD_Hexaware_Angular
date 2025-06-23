namespace Class_Web.API.Models.Auth
{
    public class RegisterRequest
    {
        public string EmailId { get; set; }  // Must not be null!
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Admin or Participant
    }
}
