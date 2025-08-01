using HealthState.Aplicacion.Tratamiento.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace HealthState.Aplicacion.Tratamiento.Commands
{
    public class TratamientoCreateCommand : IRequest<TratamientoModel>
    {
        public string? Descripcion { get; set; }

        public decimal? Costo { get; set; }

    }
}