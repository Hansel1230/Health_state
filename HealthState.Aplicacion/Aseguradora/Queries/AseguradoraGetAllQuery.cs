using HealthState.Aplicacion.Aseguradora.Models;
using HealthState.Aplicacion.Common.Models;
using MediatR;

namespace HealthState.Aplicacion.Aseguradora.Queries
{
    public record AseguradoraGetAllQuery(string? Search, int Skip = 0, int Take = 10) : IRequest<PaginationResponseModel<AseguradoraModel>> { }
}
