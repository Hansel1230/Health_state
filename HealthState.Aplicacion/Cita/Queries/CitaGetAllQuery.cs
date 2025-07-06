using HealthState.Aplicacion.Cita.Models;
using HealthState.Aplicacion.Common.Models;
using MediatR;

namespace HealthState.Aplicacion.Cita.Queries
{
    public record CitaGetAllQuery(string? Search, int Skip = 0, int Take = 10) : IRequest<PaginationResponseModel<CitaModel>> { }
}
