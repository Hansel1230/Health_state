using HealthState.Aplicacion.Clientes.Models;
using HealthState.Aplicacion.Interfaces.Clientes;
using HealthState.Aplicacion.Interfaces.Servicios;
using HealthState.Dominio.Settings;
using Microsoft.Extensions.Options;

namespace HealthState.Aplicacion.Servicios
{
    public class TokenService : ITokenService
    {
        private readonly IAvalancheAuthApiClient _avalancheApi;
        private readonly AvalancheApiSettings _apiSettings;
        private string _token;
        private DateTime _expiresAt;

        public TokenService(IAvalancheAuthApiClient avalancheApi, IOptions<AvalancheApiSettings> options)
        {
            _avalancheApi = avalancheApi;
            _apiSettings = options.Value;
        }

        public async Task<string> GetTokenAsync(CancellationToken cancellationToken = default)
        {
            if (!string.IsNullOrEmpty(_token) && DateTime.UtcNow < _expiresAt)
                return _token;

            LoginRequestModel dto = new()
            {
                UserName = _apiSettings.UserName,
                Password = _apiSettings.Password
            };

            // Aquí pones tus credenciales reales o las obtienes de la configuración
            var result = await _avalancheApi.LoginAsync(dto, cancellationToken);

            _token = result.JwToken;
            _expiresAt = result.ExpiresAt;

            return _token;
        }
    }
}
