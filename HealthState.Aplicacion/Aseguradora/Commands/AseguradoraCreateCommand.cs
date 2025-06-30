using HealthState.Aplicacion.Aseguradora.Models;
using MediatR;

namespace HealthState.Aplicacion.Aseguradora.Commands
{
    public class AseguradoraCreateCommand : IRequest<AseguradoraModel>
    {
        public string Nombre { get; set; } = null!;

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public string? Contacto { get; set; }
    }
}
