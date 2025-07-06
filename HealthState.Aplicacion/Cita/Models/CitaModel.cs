
namespace HealthState.Aplicacion.Cita.Models
{
    public class CitaModel
    {
        public int CitaId { get; set; }

        public int? PacienteId { get; set; }

        public int? MedicoId { get; set; }

        public DateTime? FechaHora { get; set; }

        public string? MotivoConsulta { get; set; }

        public int? EstadoId { get; set; }
    }
}
