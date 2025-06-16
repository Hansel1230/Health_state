namespace HealthState.Application.Auth.Models
{
    public class AuthApiLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AppCode { get; set; }
    }
}
