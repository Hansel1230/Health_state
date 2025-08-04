namespace HealthState.Aplicacion.Clientes.Models
{
    public class LoginResponseModel
    {
        public string JwToken { get; set; }
        public string ExpiresIn { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string RefreshToken { get; set; }
        public string RefreshExpiresIn { get; set; }
        public DateTime RefreshExpiresAt { get; set; }
    }
}
