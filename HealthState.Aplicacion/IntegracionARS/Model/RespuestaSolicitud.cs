using System.ComponentModel.DataAnnotations;

namespace HealthState.Aplicacion.IntegracionARS.Model
{
    public class RespuestaSolicitud
    {
        public string Estado { get; set; }
        public string? TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string? NumeroPoliza { get; set; }
        public string TipoSolicitud { get; set; }
        public int NumeroSolicitud { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
        public decimal MontoSolicitud { get; set; }
        public decimal? MontoAprobado { get; set; }
        public string Hospital { get; set; }
    }
}
