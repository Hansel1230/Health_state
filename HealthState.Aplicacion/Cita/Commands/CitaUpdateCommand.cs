using HealthState.Aplicacion.Cita.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace HealthState.Aplicacion.Cita.Commands
{
    public class CitaUpdateCommand : IRequest<CitaModel>
    {
        [JsonIgnore] public int CitaId { get; set; }
        public string PacienteCedula { get; set; }

        public string MedicoCedula { get; set; }

        public DateTime? FechaHora { get; set; }

        public string? MotivoConsulta { get; set; }

        public int? EstadoId { get; set; }
    }
}
