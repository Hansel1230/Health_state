namespace HealthState.Aplicacion.Auth.Services
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(string hash, string providedPassword);
    }
}
