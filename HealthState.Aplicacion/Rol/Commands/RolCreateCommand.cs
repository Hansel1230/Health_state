using HealthState.Aplicacion.Rol.Models;
using MediatR;

namespace HealthState.Aplicacion.Rol.Commands
{
    public class RolCreateCommand : IRequest<RolModel>
    {
        public string Nombre { get; set; } = null!;
    }
}
