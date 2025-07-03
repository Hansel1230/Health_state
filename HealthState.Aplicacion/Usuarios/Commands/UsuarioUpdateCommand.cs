using HealthState.Aplicacion.Usuarios.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace HealthState.Aplicacion.Usuarios.Commands
{
    public class UsuarioUpdateCommand : IRequest<UsuarioModel>
    {
        [JsonIgnore] public int UsuarioId { get; set; }

        public string Usuario1 { get; set; } = null!;

        public string Contrasena { get; set; } = null!;

        public int? RolId { get; set; }
    }
}
