using HealthState.Aplicacion.Clientes.Models;
using HealthState.Aplicacion.IntegracionARS.Queries.GetByIdSolicitud;
using HealthState.Aplicacion.Interfaces.Clientes;
using HealthState.Aplicacion.Interfaces.Servicios;
using HealthState.Aplicacion.IntegracionARS.Model;

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

        public async Task<AuthorizationResponseModel> MakeAuthorizationAsync(AuthorizationRequestModel request, CancellationToken cancellationToken = default)
        {
            AuthorizationResponseModel result = new();

            try
            {
                var token = await _tokenService.GetTokenAsync(cancellationToken);
                result = await _apiClient.MakeAuthorization(request, token);
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public async Task<PayBillResponseDTO> PayBillsAsync(PayBillRequestModel request, CancellationToken cancellationToken = default)
        {
            // Aquí deberías llamar al API externo real, pero puedes simular la respuesta:
            return new PayBillResponseDTO
            {
                TransferenceId = "20250805020210321",
                TotalAmount = request.Bills.Sum(b => (double)b.Amount),
                PaidAmount = 0,
                RefusedAmount = request.Bills.Sum(b => (double)b.Amount),
                Bills = request.Bills.Select(b => new BillDTO
                {
                    AuthorizationNumber = b.AuthorizationNumber.ToString(),
                    Status = "Rechazada",
                    Details = "La solicitud no fue encontrada en nuestro sistema"
                }).ToList()
            };
        }
    }
}
