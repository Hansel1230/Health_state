using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Medico.Models;
using MediatR;

namespace HealthState.Aplicacion.Medico.Queries
{
    public record MedicoGetAllQuery(string? Search, int Skip = 0, int Take = 10) : IRequest<PaginationResponseModel<MedicoModel>> { }
}
