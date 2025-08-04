using HealthState.Aplicacion.Clientes.Models;

namespace HealthState.Aplicacion.Interfaces.Clientes
{
    public interface IAvalancheAuthApiClient
    {
        Task<LoginResponseModel> LoginAsync(LoginRequestModel request, CancellationToken cancellationToken = default);
    }
}
