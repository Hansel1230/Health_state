using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Solicitud.Models;
using MediatR;

namespace HealthState.Aplicacion.Solicitud.Queries
{
    public record SolicitudGetAllQuery(string? Search, int Skip = 0, int Take = 10) : IRequest<PaginationResponseModel<SolicitudModel>> { }
}
