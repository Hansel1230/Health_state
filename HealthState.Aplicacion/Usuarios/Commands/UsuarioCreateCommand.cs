using HealthState.Aplicacion.Usuarios.Models;
using MediatR;

namespace HealthState.Aplicacion.Usuarios.Commands
{
    public class UsuarioCreateCommand : IRequest<UsuarioModel>
    {
        public string Usuario1 { get; set; } = null!;

        public string Contrasena { get; set; } = null!;

        public int? RolId { get; set; }
    }
}
