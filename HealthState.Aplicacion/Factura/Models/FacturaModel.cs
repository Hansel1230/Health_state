namespace HealthState.Aplicacion.Factura.Models
{
    public class FacturaModel
    {
        public int FacturaId { get; set; }

        public int? PacienteId { get; set; }

        public DateOnly? FechaEmision { get; set; }

        public decimal? Monto { get; set; }

        public bool? Pagado { get; set; }
    }
}
