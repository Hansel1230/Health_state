using System;

namespace HealthState.Application.Auth.Models
{
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public DateTime? Expire { get; set; }
    }
}
