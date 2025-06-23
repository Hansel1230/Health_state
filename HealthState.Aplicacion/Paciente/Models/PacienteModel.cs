namespace HealthState.Aplicacion.Paciente.Models
{
    public class PacienteModel
    {
        public string Nombre { get; set; } = null!;

        public DateOnly? FechaNacimiento { get; set; }

        public string? Sexo { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }
    }
}
