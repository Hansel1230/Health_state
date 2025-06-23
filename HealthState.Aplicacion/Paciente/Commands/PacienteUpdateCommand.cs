using HealthState.Aplicacion.Paciente.Models;
using MediatR;
using System.Text.Json.Serialization;
namespace HealthState.Aplicacion.Paciente.Commands
{
    public class PacienteUpdateCommand : IRequest<PacienteModel>
    {
        [JsonIgnore] public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateOnly? FechaNacimiento { get; set; }
        public string? Sexo { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Cedula { get; set; }
        public string? Email { get; set; }
        public int? PolizaId { get; set; }
        public int? AseguradoraId { get; set; }
    }
}
