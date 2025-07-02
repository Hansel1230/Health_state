using HealthState.Aplicacion.Medico.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace HealthState.Aplicacion.Medico.Commands
{
    public class MedicoUpdateCommand : IRequest<MedicoModel>
    {
        [JsonIgnore] public int MedicoId { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Apellido { get; set; }

        public string? Especialidad { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public string? Cedula { get; set; }
    }
}
