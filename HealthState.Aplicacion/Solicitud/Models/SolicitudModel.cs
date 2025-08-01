namespace HealthState.Aplicacion.Solicitud.Models
{
    public class SolicitudModel
    {
        public int SolicitudId { get; set; }

        public string? Descripcion { get; set; }

        public string Estado { get; set; }

        public string TipoSolicitud { get; set; }

        public decimal? MontoTotal { get; set; }

        public decimal? MontoAprobado { get; set; }

        public int? PolizaId { get; set; }

        public string? Cedula { get; set; }

        public string Aseguradora { get; set; }

        public string? Observaciones { get; set; }
    }
}
