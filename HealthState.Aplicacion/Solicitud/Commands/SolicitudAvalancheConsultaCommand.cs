using MediatR;
using HealthState.Aplicacion.IntegracionARS.Model;

namespace HealthState.Aplicacion.Solicitud.Commands
{
    public class SolicitudAvalancheConsultaCommand : IRequest<RespuestaSolicitud>
    {
        public string? TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public int? NumeroPoliza { get; set; }
        public string TipoSolicitud { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
        public decimal MontoSolicitud { get; set; }
    }
}