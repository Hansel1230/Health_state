namespace HealthState.Aplicacion.Aseguradora.Models
{
    public class AseguradoraModel
    {
        public int AseguradoraId { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public string? Contacto { get; set; }

        //public int PacienteId { get; set; }

        //public virtual ICollection<Solicitude> Solicitudes { get; set; } = new List<Solicitude>();
    }
}
