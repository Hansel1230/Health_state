using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Factura.Models;
using MediatR;

namespace HealthState.Aplicacion.Factura.Queries
{
    public record FacturaGetAllQuery(string? Search, DateOnly? FechaInicio, DateOnly? FechaFin, int Skip = 0, int Take = 10) : IRequest<PaginationResponseModel<FacturaModel>> { }
}
