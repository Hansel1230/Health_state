using HealthState.Aplicacion.Factura.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace HealthState.Aplicacion.Factura.Commands
{
    public class FacturaCreateCommand : IRequest<FacturaModel>
    {
        public string? Cedula { get; set; }

        [JsonIgnore] public DateOnly? FechaEmision { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public decimal? Monto { get; set; }

        [JsonIgnore] public bool? Pagado { get; set; } = false;
    }
}
