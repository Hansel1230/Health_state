using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Tratamiento.Models;
using MediatR;

namespace HealthState.Aplicacion.Tratamiento.Queries
{
    public record TratamientoGetAllQuery(string? search, int Skip = 0, int Take = 10) : IRequest<PaginationResponseModel<TratamientoModel>> { }

}