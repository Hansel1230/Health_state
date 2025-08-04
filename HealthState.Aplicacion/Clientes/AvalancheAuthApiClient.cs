using HealthState.Aplicacion.Clientes.Models;
using HealthState.Aplicacion.Interfaces.Clientes;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace HealthState.Aplicacion.Clientes
{
    public class AvalancheAuthApiClient : IAvalancheAuthApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AvalancheAuthApiClient> _logger;

        public AvalancheAuthApiClient(HttpClient httpClient, ILogger<AvalancheAuthApiClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<LoginResponseModel> LoginAsync(LoginRequestModel request, CancellationToken cancellationToken = default)
        {
            LoginResponseModel token = new();
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/v1/account/login", content, cancellationToken);
                response.EnsureSuccessStatusCode();
                _logger.LogInformation("Se obtuvo el token satisfactoriamente");

                var result = await response.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<LoginResponseModel>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hubo un error al intentar obtener token del API");
                throw;
            }

            return token;
        }
    }
}
