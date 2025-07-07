using MediatR;

namespace HealthState.Aplicacion.DetalleFactura.Commands
{
    public class DetalleFacturaDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
