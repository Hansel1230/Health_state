using HealthState.Aplicacion.Rol.Models;
using MediatR;

namespace HealthState.Aplicacion.Rol.Queries
{
    public record RolGetAllQuery : IRequest<IEnumerable<RolModel>> { }

}
