using HealthState.Aplicacion.Clientes.Models;
using HealthState.Aplicacion.IntegracionARS.Queries.GetByIdSolicitud;

namespace HealthState.Aplicacion.Interfaces.Clientes
{
    public interface IAvalancheApiClient
    {
        Task<GetByIdSolicitudQueryResponse> GetAuthorizationById(int id, string token, CancellationToken cancellationToken = default);
        Task<AffiliateModel> ValidateAffiliate(ValidateAffiliateRequestModel query, string token, CancellationToken cancellationToken = default);
    }
}
