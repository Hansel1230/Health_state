using HealthState.Aplicacion.Factura.Models;
using MediatR;

namespace HealthState.Aplicacion.Factura.Queries
{
    public record FacturaGetByIdQuery(int Id) : IRequest<FacturaModel> { }
}
