using MediatR;

namespace HealthState.Aplicacion.Cita.Commands
{
    public class CitaDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
