using MediatR;

namespace HealthState.Aplicacion.Rol.Commands
{
    public class RolDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
