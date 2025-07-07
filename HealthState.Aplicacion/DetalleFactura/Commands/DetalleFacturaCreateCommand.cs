using HealthState.Aplicacion.DetalleFactura.Models;
using MediatR;

namespace HealthState.Aplicacion.DetalleFactura.Commands
{
    public class DetalleFacturaCreateCommand : IRequest<DetalleFacturaModel>
    {
        public int? FacturaId { get; set; }

        public int? TratamientoId { get; set; }

        public decimal? Monto { get; set; }
    }
}
