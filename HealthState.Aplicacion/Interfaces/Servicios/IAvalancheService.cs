using HealthState.Aplicacion.Clientes.Models;
using HealthState.Aplicacion.IntegracionARS.Queries.GetByIdSolicitud;
using HealthState.Aplicacion.IntegracionARS.Model;

namespace HealthState.Aplicacion.Interfaces.Servicios
{
    public interface IAvalancheService
    {
        Task<GetByIdSolicitudQueryResponse> GetAuthorizationAsync(int id, CancellationToken cancellationToken = default);
        Task<AffiliateModel> ValidateAffiliateAsync(ValidateAffiliateRequestModel request, CancellationToken cancellationToken = default);
        Task<AuthorizationResponseModel> MakeAuthorizationAsync(AuthorizationRequestModel request, CancellationToken cancellationToken = default);
        Task<PayBillResponseDTO> PayBillsAsync(PayBillRequestModel request, CancellationToken cancellationToken = default);
    }
}
