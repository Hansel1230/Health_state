using System;

namespace HealthState.Aplicacion.Auth.Models
{
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public DateTime? Expire { get; set; }
    }
}
