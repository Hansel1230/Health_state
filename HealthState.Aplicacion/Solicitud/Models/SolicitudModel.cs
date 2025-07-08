namespace HealthState.Aplicacion.Solicitud.Models
{
    public class SolicitudModel
    {
        public int SolicitudId { get; set; }

        public string? Descripcion { get; set; }

        public int? EstadoId { get; set; }

        public int? TipoId { get; set; }

        public decimal? MontoTotal { get; set; }

        public decimal? MontoAprobado { get; set; }

        public int? PolizaId { get; set; }

        public string? Cedula { get; set; }

        public int? AseguradoraId { get; set; }

        public string? Observaciones { get; set; }
    }
}
