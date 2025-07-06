namespace HealthState.Aplicacion.Tratamiento.Models
{
    public class TratamientoModel
    {
        public int TratamientoId { get; set; }

        public int? CitaId { get; set; }

        public string? Descripcion { get; set; }

        public DateOnly? Fecha { get; set; }

        public decimal? Costo { get; set; }

        public bool? Cubierto { get; set; }
    }
}