using HealthState.Application.Auth.Models;

namespace HealthState.Application.Auth.Services
{
    public interface IAuthHttpService
    {
        Task<AuthApiUserModel> LoginAsync(AuthApiLoginModel model);
    }
}
