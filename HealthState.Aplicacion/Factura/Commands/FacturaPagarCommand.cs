using HealthState.Aplicacion.Factura.Models;
using MediatR;

namespace HealthState.Aplicacion.Factura.Commands
{
    public class FacturaPagarCommand : IRequest<FacturaModel>
    {
        public int FacturaId { get; set; }
    }
}