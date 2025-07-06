using HealthState.Aplicacion.Cita.Models;
using MediatR;

namespace HealthState.Aplicacion.Cita.Commands
{
    public class CitaCreateCommand : IRequest<CitaModel>
    {
        public string? PacienteCedula { get; set; }

        public string? MedicoCedula { get; set; }

        public DateTime? FechaHora { get; set; }

        public string? MotivoConsulta { get; set; }

        public int? EstadoId { get; set; }
    }
}
