using MediatR;

namespace HealthState.Aplicacion.Solicitud.Commands
{
    public class SolicitudDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
