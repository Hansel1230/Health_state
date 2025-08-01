using HealthState.Aplicacion.Solicitud.Models;
using HealthState.Dominio.Enum;
using MediatR;
using System.Text.Json.Serialization;

namespace HealthState.Aplicacion.Solicitud.Commands
{
    public class SolicitudUpdateEstadoCommand : IRequest<SolicitudModel> 
    {
        [JsonIgnore] public int SolicitudId { get; set; }
        public EstadoEnum NuevoEstado { get; set; } 
        public decimal? MontoAprobado { get; set; }
    }
}
