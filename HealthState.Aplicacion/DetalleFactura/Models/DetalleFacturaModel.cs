namespace HealthState.Aplicacion.DetalleFactura.Models
{
    public class DetalleFacturaModel
    {
        public int DetalleId { get; set; }

        public int? FacturaId { get; set; }

        public int? TratamientoId { get; set; }

        public decimal? Monto { get; set; }
    }
}
