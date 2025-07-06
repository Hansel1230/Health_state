using HealthState.Aplicacion.Tratamiento.Models;
using MediatR;

namespace HealthState.Aplicacion.Tratamiento.Queries
{
    public record TratamientoGetByIdQuery(int Id) : IRequest<TratamientoModel> { }
}