using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Paciente.Models;
using MediatR;

namespace HealthState.Aplicacion.Paciente.Queries
{
    public record PacienteGetAllQuery(string? search, int Skip = 0, int Take = 10) : IRequest<PaginationResponseModel<PacienteModel>> { }

}
