using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Usuarios.Models;
using MediatR;

namespace HealthState.Aplicacion.Usuarios.Queries
{
    public record UsuarioGetAllQuery(string? Search, int Skip = 0, int Take = 10) : IRequest<PaginationResponseModel<UsuarioModel>> { }

}
