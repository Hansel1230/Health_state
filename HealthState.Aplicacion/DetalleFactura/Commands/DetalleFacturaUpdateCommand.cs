using HealthState.Aplicacion.DetalleFactura.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace HealthState.Aplicacion.DetalleFactura.Commands
{
    public class DetalleFacturaUpdateCommand : IRequest<DetalleFacturaModel>
    {
        [JsonIgnore] public int DetalleId { get; set; }

        public int? FacturaId { get; set; }

        public int? TratamientoId { get; set; }

        public decimal? Monto { get; set; }
    }
}
