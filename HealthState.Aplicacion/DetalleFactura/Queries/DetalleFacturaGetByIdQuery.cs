using HealthState.Aplicacion.DetalleFactura.Models;
using MediatR;

namespace HealthState.Aplicacion.DetalleFactura.Queries
{
    public record DetalleFacturaGetByIdQuery(int Id) : IRequest<DetalleFacturaModel> { }
}
