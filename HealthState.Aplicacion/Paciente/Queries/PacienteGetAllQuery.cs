using HealthState.Aplicacion.Paciente.Models;
using MediatR;

namespace HealthState.Aplicacion.Paciente.Queries
{
    public record PacienteGetAllQuery : IRequest<IEnumerable<PacienteModel>> { }

}
