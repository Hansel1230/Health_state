using HealthState.Aplicacion.Solicitud.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace HealthState.Aplicacion.Solicitud.Commands
{
    public class SolicitudCreateCommand : IRequest<SolicitudModel>
    {
        public string? Descripcion { get; set; }

        public int? EstadoId { get; set; }

        public int? TipoId { get; set; }

        public decimal? MontoTotal { get; set; }

        [JsonIgnore] public decimal? MontoAprobado { get; set; } = 0;

        public string? Cedula { get; set; }

        public string? Observaciones { get; set; }
    }
}
