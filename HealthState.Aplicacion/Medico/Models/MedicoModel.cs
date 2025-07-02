namespace HealthState.Aplicacion.Medico.Models
{
    public class MedicoModel
    {
        public int MedicoId { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Apellido { get; set; }

        public string? Especialidad { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public string? Cedula { get; set; }
    }
}
