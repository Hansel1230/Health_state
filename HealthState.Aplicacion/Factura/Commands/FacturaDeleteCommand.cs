using MediatR;

namespace HealthState.Aplicacion.Factura.Commands
{
    public class FacturaDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
