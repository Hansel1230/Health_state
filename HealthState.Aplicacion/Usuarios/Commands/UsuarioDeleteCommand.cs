using MediatR;

namespace HealthState.Aplicacion.Usuarios.Commands
{
    public class UsuarioDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
