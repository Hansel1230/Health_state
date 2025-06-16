using HealthState.Aplicacion.Auth.Models;

namespace HealthState.Aplicacion.Auth.Services
{
    public interface IAuthHttpService
    {
        Task<AuthApiUserModel> LoginAsync(AuthApiLoginModel model);
    }
}
