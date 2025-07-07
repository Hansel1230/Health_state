using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.DetalleFactura.Models;
using MediatR;

namespace HealthState.Aplicacion.DetalleFactura.Queries
{
    public record DetalleFacturaGetAllQuery(string? Search, int Skip = 0, int Take = 10) : IRequest<PaginationResponseModel<DetalleFacturaModel>> { }
}
