using HealthState.Aplicacion.Clientes.Models;
using HealthState.Aplicacion.IntegracionARS.Model;
using HealthState.Aplicacion.IntegracionARS.Queries.GetByIdSolicitud;

namespace HealthState.Aplicacion.Interfaces.Clientes
{
    public interface IAvalancheApiClient
    {
        Task<GetByIdSolicitudQueryResponse> GetAuthorizationById(int id, string token, CancellationToken cancellationToken = default);
        Task<AffiliateModel> ValidateAffiliate(ValidateAffiliateRequestModel query, string token, CancellationToken cancellationToken = default);
        Task<AuthorizationResponseModel> MakeAuthorization(AuthorizationRequestModel request, string token, CancellationToken cancellationToken = default);
        Task<PayBillResponseDTO> PayBillsAsync(PayBillRequestModel request, string token, CancellationToken cancellationToken = default);
    }
}
