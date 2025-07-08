using HealthState.Aplicacion.Solicitud.Models;
using MediatR;

namespace HealthState.Aplicacion.Solicitud.Queries
{
    public record SolicitudGetByIdQuery(int Id) : IRequest<SolicitudModel> { }
}
