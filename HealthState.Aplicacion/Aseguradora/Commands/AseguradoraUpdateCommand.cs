using HealthState.Aplicacion.Aseguradora.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace HealthState.Aplicacion.Aseguradora.Commands
{
    public class AseguradoraUpdateCommand : IRequest<AseguradoraModel>
    {
        [JsonIgnore] public int AseguradoraId { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public string? Contacto { get; set; }
    }
}
