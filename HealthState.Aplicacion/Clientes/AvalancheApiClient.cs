using HealthState.Aplicacion.Clientes.Models;
using HealthState.Aplicacion.IntegracionARS.Queries.GetByIdSolicitud;
using HealthState.Aplicacion.Interfaces.Clientes;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HealthState.Aplicacion.Clientes
{
    public class AvalancheApiClient : IAvalancheApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AvalancheApiClient> _logger;

        public AvalancheApiClient(HttpClient httpClient, ILogger<AvalancheApiClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<GetByIdSolicitudQueryResponse> GetAuthorizationById(int id, string token, CancellationToken cancellationToken = default)
        {
            GetByIdSolicitudQueryResponse result = new();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"api/v1/hospitales/integracion/check-authorization/{id}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.SendAsync(request, cancellationToken);
                response.EnsureSuccessStatusCode();
                _logger.LogInformation("Se obtuvo la autorización satisfactoriamente");

                var responseContent = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<GetByIdSolicitudQueryResponse>(responseContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hubo un error al intentar obtener token del API");
                throw;
            }

            return result;
        }

        public async Task<AffiliateModel> ValidateAffiliate(ValidateAffiliateRequestModel query, string token, CancellationToken cancellationToken = default)
        {
            AffiliateModel result = new();
            try
            {
                var url = QueryHelpers.AddQueryString($"{_httpClient.BaseAddress}api/v1/hospitales/integracion/validate-affiliate", new Dictionary<string, string>
                {
                    { "documentType", query.DocumentType },
                    { "documentNumber", query.DocumentNumber },
                    { "policyNumber", query.PolicyNumber }
                });

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.SendAsync(request, cancellationToken);
                response.EnsureSuccessStatusCode();
                _logger.LogInformation("Se obtuvo la autorización satisfactoriamente");

                var responseContent = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<AffiliateModel>(responseContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hubo un error al intentar obtener token del API");
                throw;
            }

            return result;
        }
    }
}
