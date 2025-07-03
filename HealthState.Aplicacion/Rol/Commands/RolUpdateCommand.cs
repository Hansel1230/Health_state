using HealthState.Aplicacion.Rol.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace HealthState.Aplicacion.Rol.Commands
{
    public class RolUpdateCommand : IRequest<RolModel>
    {
        [JsonIgnore] public int RolId { get; set; }

        public string Nombre { get; set; } = null!;
    }
}
