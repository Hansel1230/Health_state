using HealthState.Aplicacion.Clientes.Models;
using HealthState.Aplicacion.IntegracionARS.Queries.GetByIdSolicitud;
using HealthState.Aplicacion.Interfaces.Clientes;
using HealthState.Aplicacion.Interfaces.Servicios;

namespace HealthState.Aplicacion.Servicios
{
    public class AvalancheService : IAvalancheService
    {
        private readonly ITokenService _tokenService;
        private readonly IAvalancheApiClient _apiClient;

        public AvalancheService(ITokenService tokenService, IAvalancheApiClient apiClient)
        {
            _tokenService = tokenService;
            _apiClient = apiClient;
        }

        public async Task<GetByIdSolicitudQueryResponse> GetAuthorizationAsync(int id, CancellationToken cancellationToken = default)
        {
            GetByIdSolicitudQueryResponse result = new();

            try
            {
                var token = await _tokenService.GetTokenAsync(cancellationToken);
                result = await _apiClient.GetAuthorizationById(id, token);
            }
            catch (Exception ex)
            {
                throw;
            }
            
            return result;
        }

        public async Task<AffiliateModel> ValidateAffiliateAsync(ValidateAffiliateRequestModel request, CancellationToken cancellationToken = default)
        {
            AffiliateModel result = new();

            try
            {
                var token = await _tokenService.GetTokenAsync(cancellationToken);
                result = await _apiClient.ValidateAffiliate(request, token);
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }
    }
}
