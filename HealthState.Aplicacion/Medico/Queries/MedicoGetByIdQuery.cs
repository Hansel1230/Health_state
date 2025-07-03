using HealthState.Aplicacion.Medico.Models;
using MediatR;

namespace HealthState.Aplicacion.Medico.Queries
{
    public record MedicoGetByIdQuery(int Id) : IRequest<MedicoModel> { }
}
