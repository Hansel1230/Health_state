using HealthState.Dominio;

namespace HealthState.Aplicacion.Paciente.Models
{
    public class PacienteModel
    {
        public int PacienteId { get; set; }

        public string Nombre { get; set; } = null!;

        public DateOnly? FechaNacimiento { get; set; }

        public string? Sexo { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }
        public string? Cedula { get; set; }
        public string? Email { get; set; }
        public int? PolizaId { get; set; }
        public string? Aseguradora { get; set; }

    }
}
