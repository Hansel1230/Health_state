using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Paciente.Models;
using MediatR;

namespace HealthState.Aplicacion.Paciente.Queries
{
    public record PacienteGetByIdQuery(int Id) : IRequest<PacienteModel> { }

}
