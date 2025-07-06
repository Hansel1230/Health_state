using HealthState.Aplicacion.Cita.Models;
using MediatR;

namespace HealthState.Aplicacion.Cita.Queries
{
    public record CitaGetByIdQuery(int Id) : IRequest<CitaModel> { }
}
