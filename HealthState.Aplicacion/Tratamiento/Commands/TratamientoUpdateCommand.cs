using HealthState.Aplicacion.Tratamiento.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace HealthState.Aplicacion.Tratamiento.Commands
{
    public class TratamientoUpdateCommand : IRequest<TratamientoModel>
    {
        [JsonIgnore] public int TratamientoId { get; set; }

        public int? CitaId { get; set; }

        public string? Descripcion { get; set; }

        public DateOnly? Fecha { get; set; }

        public decimal? Costo { get; set; }

        public bool? Cubierto { get; set; }
    }
}